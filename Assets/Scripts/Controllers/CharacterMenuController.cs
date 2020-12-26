using InputSystem;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public class CharacterMenuController : MonoBehaviour
    {
        [SerializeField] private Image _mouseImage, _keyboardImage;
        [SerializeField] private MouseListener _mouseListener;
        [SerializeField] private KeyboardListener _keyboardListener;
    }
}
