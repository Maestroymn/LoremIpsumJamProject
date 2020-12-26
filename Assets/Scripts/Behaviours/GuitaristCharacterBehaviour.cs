using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Behaviours
{
    public class GuitaristCharacterBehaviour : MonoBehaviour
    {
        public CharacterSituation CharacterSituation;
        public float Angle;
        private bool _isJoystickClaimed, _isJoystickPressed, _isMouseClaimed;
        private Vector2 _mouseDir;
        private float _vertical;
        [SerializeField] private MouseJoystickListener joystickListener;
        [SerializeField] private MouseListener mouseListener;
        [SerializeField] public Rigidbody2D Rigidbody2D;
        [SerializeField] private DrumCharacterBehaviour _drumCharacter;
        private void StartInputSelectionRoutine()
        {
            StartCoroutine(GuitaristSelectInput());
        }
        
        private void FixedUpdate()
        {
            if(CharacterSituation==CharacterSituation.OnMap)
            {
                LookAtMouse();
            }
        }
        
        void LookAtMouse()
        {
            if (!(Camera.main is null))
                _mouseDir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            Angle = Mathf.Atan2(_mouseDir.y, _mouseDir.x) * Mathf.Rad2Deg;
            _drumCharacter.transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
            transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
        }

        private IEnumerator GuitaristSelectInput()
        {
            while (CharacterSituation==CharacterSituation.InputSelectionStage)
            {
                if (Input.GetMouseButton(0) && !_isMouseClaimed)
                {
                    _isMouseClaimed = true;
                    Debug.Log("Tıkladım Mouse");
                    mouseListener.LeftClick += OnLeftClick;
                    mouseListener.RightClick += OnRightClick;
                    mouseListener.LeftClickDraggedUp += OnLeftClickDragUp;
                    mouseListener.LeftClickDraggedDown += OnLeftClickDragDown;
                    mouseListener.RightClickDraggedUp += OnRightClickDragUp;
                    mouseListener.RightClickDraggedDown += OnRightClickDragDown;
                    _isJoystickClaimed = false;
                }
                if (Input.GetButton("RB2") && !_isJoystickClaimed)
                {
                    _isJoystickClaimed = true;
                    Debug.Log("Joystick Added");
                    joystickListener.JoystickLeftOne += OnJoystickLeftOne;
                    joystickListener.JoystickRightOne += OnJoystickRightOne;
                    joystickListener.JoystickLeftDraggedUp += OnJoystickLeftDragUp;
                    joystickListener.JoystickLeftDraggedDown += OnJoystickLeftDragDown;
                    joystickListener.JoystickRightDraggedUp += OnJoystickRightDragUp;
                    joystickListener.JoystickRightDraggedDown += OnJoystickRightDragDown;
                    _isMouseClaimed = false;
                }
                yield return null;
            }
        }

        // Mouse Inputs
        private void OnLeftClick(PointerEventData eventData)
        {

        }

        private void OnRightClick(PointerEventData eventData)
        {

        }
    
        private void OnLeftClickDragUp(PointerEventData eventData)
        {

        }

        private void OnLeftClickDragDown(PointerEventData eventData)
        {

        }

        private void OnRightClickDragUp(PointerEventData eventData)
        {

        }

        private void OnRightClickDragDown(PointerEventData eventData)
        {

        }

        // Joystick Inputs
        private void OnJoystickRightOne()
        {

        }

        private void OnJoystickLeftOne()
        {

        }

        private void OnJoystickLeftDragUp()
        {

        }

        private void OnJoystickLeftDragDown()
        {

        }

        private void OnJoystickRightDragUp()
        {

        }

        private void OnJoystickRightDragDown()
        {

        }
        
    }
}
