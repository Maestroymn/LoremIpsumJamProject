using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIManager _uiManager; 
        [SerializeField] private ArenaManager _arenaManager;
        private Image _fadeImage;

        private void Awake()
        {
            _uiManager._mainMenu.Initialize();
            _fadeImage = _uiManager._fadeImage;
        }

        public void StartArena()
        {
            LeanTween.alpha(_fadeImage.rectTransform, 1, 2f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
            {
                _uiManager._characterMenuController.gameObject.SetActive(false);
                LeanTween.alpha(_fadeImage.rectTransform, 0, 2f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
                {
                    _arenaManager.StartArena1();
                });
            });
        }
    }
}
