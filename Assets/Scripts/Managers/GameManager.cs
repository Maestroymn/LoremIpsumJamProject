using System.Collections;
using Behaviours;
using Controllers;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager; 
        [SerializeField] private ArenaManager _arenaManager;
        [SerializeField] private MapController _mapController;
        [SerializeField] private CameraFollow _camera;
        [SerializeField] public VideoPlayer _introduce;
        [SerializeField] public VideoPlayer _badEnd;
        [SerializeField] public VideoPlayer _goodEnd;

        private Image _fadeImage;

        private void Awake()
        {
            _uiManager._mainMenu.Initialize();
            _fadeImage = _uiManager._fadeImage;
        }

        public void StartArena(Arena ArenaLevel)
        {
            LeanTween.alpha(_fadeImage.rectTransform, 1, 2f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
            {
                //_uiManager._characterMenuController.gameObject.SetActive(false);
                _mapController.gameObject.SetActive(false);
                _camera.isFollowing = false;
                _camera.transform.position=new Vector3(0f,0f,-10f);
                LeanTween.alpha(_fadeImage.rectTransform, 0, 2f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
                {
                    if (ArenaLevel == Arena.Arena1)
                    {
                        _arenaManager.StartArena1();
                    }else if (ArenaLevel == Arena.Arena2)
                    {
                        _arenaManager.StartArena2();
                    }else if (ArenaLevel == Arena.Arena3)
                    {
                        _arenaManager.StartArena3();
                    }
                });
            });
        }
        
        public void ReturnToMap(GameObject lastArena)
        {
            LeanTween.alpha(_fadeImage.rectTransform, 1, 2f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
            {
                lastArena.gameObject.SetActive(false);
                _camera.transform.position = new Vector3(0f, 0f, -10f);
                _mapController.gameObject.SetActive(false);
                //_mapController.gameObject.SetActive(false);
                LeanTween.alpha(_fadeImage.rectTransform, 0, 2f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
                {
                    _introduce.gameObject.SetActive(true);
                    _introduce.Play();
                    _camera.isFollowing = true;
                    _mapController.Initialize();
                });
            });
        }
        
        
        public void GoodEnd(GameObject lastArena)
        {
            LeanTween.alpha(_fadeImage.rectTransform, 1, 2f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
            {
                lastArena.gameObject.SetActive(false);
                _camera.transform.position = new Vector3(0f, 0f, -10f);
                _mapController.gameObject.SetActive(false);
                //_mapController.gameObject.SetActive(false);
                LeanTween.alpha(_fadeImage.rectTransform, 0, 2f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
                {
                    _goodEnd.gameObject.SetActive(true);
                    _goodEnd.Play();
                    StartCoroutine(Waitforvideo(_goodEnd.length));
                });
            });
        }


        private IEnumerator Waitforvideo(double vidlenght)
        {
            yield return new WaitForSeconds((float)vidlenght);
            _uiManager._mainMenu.gameObject.SetActive(true);
            _goodEnd.gameObject.SetActive(false);
        }
        public void BadEnd(GameObject lastArena)
        {
            LeanTween.alpha(_fadeImage.rectTransform, 1, 2f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
            {
                lastArena.gameObject.SetActive(false);
                _camera.transform.position = new Vector3(0f, 0f, -10f);
                LeanTween.alpha(_fadeImage.rectTransform, 0, 2f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
                {
                    _badEnd.gameObject.SetActive(true);
                    _badEnd.Play();
                    _uiManager._mainMenu.gameObject.SetActive(true);
                });
            });
        }
        
    }
}
