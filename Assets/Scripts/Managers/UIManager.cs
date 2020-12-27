using System;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] public Image _fadeImage;
        [SerializeField] public CharacterMenuController _characterMenuController;
        [SerializeField] private SettingsMenu _settingsMenu;
        [SerializeField] public MainMenuController _mainMenu;

        public void SwitchToCharacterScene()
        {
            LeanTween.alpha(_fadeImage.rectTransform, 1, .75f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
            {
                _mainMenu.gameObject.SetActive(false);
                _characterMenuController.gameObject.SetActive(true);
                LeanTween.alpha(_fadeImage.rectTransform, 0, 2f).setEase(LeanTweenType.easeInCirc).setOnComplete(() =>
                {
                    _characterMenuController.Initialize();
                });
            });
        }
    }
}
