using System.Collections;
using InputSystem;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Controllers
{
    public class CharacterMenuController : MonoBehaviour
    {
        [SerializeField] private Image _mouseImage, _keyboardImage;
        [SerializeField] private MouseListener _mouseListener;
        [SerializeField] private KeyboardListener _keyboardListener;
        [SerializeField] private SkylineScroller _skylineScroller;
        [SerializeField] private Animator _drummerAnimator, _guitarAnimator;
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private AudioClip _guitarCharSelectVFX,_drumCharSelectVFX;
        [SerializeField] private AudioSource _audioSource;
        private static readonly int Selected = Animator.StringToHash("Selected");
        private int _readyPlayers;
        public void Initialize()
        {
            _skylineScroller.Initialize();
            _mouseListener.LeftClick += MouseClicked;
            _keyboardListener.FirstKeyPressed += KeyboardInteraction;
        }

        public void MouseClicked(PointerEventData eventData)
        {
            _mouseListener.LeftClick -= MouseClicked;
            LeanTween.alpha(_mouseImage.rectTransform, 255, .1f).setOnComplete(() =>
            {
                _guitarAnimator.SetTrigger(Selected);
                _audioSource.clip = _guitarCharSelectVFX;
                _audioSource.Play();
                _readyPlayers++;
                if (_readyPlayers == 2)
                {
                    StartCoroutine(WaitUntilSoundFinish(_audioSource.clip.length));
                }
            });
        }
        
        public void KeyboardInteraction()
        {
            _keyboardListener.FirstKeyPressed -= KeyboardInteraction;
            LeanTween.alpha(_keyboardImage.rectTransform, 255, .1f).setOnComplete(() =>
            {
                _drummerAnimator.SetTrigger(Selected);
                _readyPlayers++;
                _audioSource.clip = _drumCharSelectVFX;
                _audioSource.Play();
                if (_readyPlayers == 2)
                {
                    StartCoroutine(WaitUntilSoundFinish(_audioSource.clip.length));
                }
            });
        }
        
        private IEnumerator WaitUntilSoundFinish(float delay)
        {
            yield return new WaitForSeconds(delay);
            _gameManager.ReturnToMap(gameObject);
        }
    }
}
