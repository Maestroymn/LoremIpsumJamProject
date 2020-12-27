using InputSystem;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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
                _readyPlayers++;
                if (_readyPlayers == 2)
                {
                    _gameManager.StartArena();
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
                if (_readyPlayers == 2)
                {
                    _gameManager.StartArena();
                }
            });
        }
    }
}
