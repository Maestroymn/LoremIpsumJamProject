using System;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Image _fadeImage;
        [SerializeField] private CharacterMenuController _characterMenuController;
        [SerializeField] private SettingsMenu _settingsMenu;
        [SerializeField] private MainMenuController _mainMenu;
        [SerializeField] private ArenaManager _arenaManager;
        public void SceneChange()
        {
            LeanTween.alpha(_fadeImage.rectTransform, 1, 2f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
            {
                LeanTween.alpha(_fadeImage.rectTransform, 0, 2f).setEase(LeanTweenType.easeInCirc);
            });
        }

        public void SwitchToCharacterScene()
        {
            LeanTween.alpha(_fadeImage.rectTransform, 1, .75f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
            {
                _mainMenu.gameObject.SetActive(false);
                _characterMenuController.gameObject.SetActive(true);
                LeanTween.alpha(_fadeImage.rectTransform, 0, 2f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
                {
                    _characterMenuController.Initialize(this);
                });
            });
        }
    }
}
