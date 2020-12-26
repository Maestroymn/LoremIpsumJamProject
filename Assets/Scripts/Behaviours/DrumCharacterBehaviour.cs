using System.Collections;
using InputSystem;
using UnityEngine;

namespace Behaviours
{
    public enum CharacterSituation
    {
        OnMap,
        OnArena,
        InputSelectionStage
    }
    public class DrumCharacterBehaviour : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 50;
        [SerializeField] private GuitaristCharacterBehaviour _guitaristCharacter;
        [SerializeField] public Rigidbody2D DrummerRigidBody;
        [SerializeField] private KeyboardListener _keyboardListener;
        [SerializeField] private KeyboardJoystickListener _keyboardJoystickListener;

        private float _vertical;
        private Vector3 _direction;
        private bool _isJoystickClaimed, _isJoystickPressed, _isKeyboardClaimed;

        public CharacterSituation CharacterSituation;
        
        private void StartInputSelectionRoutine()
        {
            StartCoroutine(DrummerSelectInputs());
        }
        
        private void FixedUpdate()
        {
            if(CharacterSituation==CharacterSituation.OnMap)
            {
                MovementBehaviour();
            }
        }

        void MovementBehaviour()
        {
            _vertical = Input.GetAxis("Vertical");
            Vector3 _newAngle = new Vector2(Mathf.Cos(_guitaristCharacter.Angle * Mathf.PI / 180f), Mathf.Sin(_guitaristCharacter.Angle * Mathf.PI / 180f));
            _direction = _vertical * _newAngle;
            if (!(Camera.main is null) && Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) < 0.2f)
            {
                _direction = Vector3.zero;
            }
            DrummerRigidBody.velocity = _direction * movementSpeed * Time.deltaTime;
            _guitaristCharacter.Rigidbody2D.velocity = _direction * movementSpeed * Time.deltaTime;
        }

        private IEnumerator DrummerSelectInputs()
        {
            while (CharacterSituation==CharacterSituation.InputSelectionStage)
            {
                if (Input.GetKeyDown(KeyCode.Space) && !_isKeyboardClaimed)
                {
                    _isKeyboardClaimed = true;
                    _isJoystickClaimed = false;
                    _isJoystickPressed = false;
                    _keyboardListener.FirstKeyPressed += OnFirstKeyPressed;
                    _keyboardListener.SecondKeyPressed += OnSecondKeyPressed;
                    _keyboardListener.ThirdKeyPressed += OnThirdKeyPressed;
                    _keyboardListener.FourthKeyPressed += OnFourthKeyPressed;
                    _keyboardListener.FifthKeyPressed += OnFifthKeyPressed;
                    _keyboardListener.SixthKeyPressed += OnSixthKeyPressed;
                }

                if (Input.GetButton("SouthButton1") && !_isJoystickClaimed)
                {
                    _isJoystickClaimed = true;
                    _isKeyboardClaimed = false;
                    _keyboardJoystickListener.JoystickRightTwo += OnFirstKeyPressed;
                    _keyboardJoystickListener.JoystickLeftTwo += OnSecondKeyPressed;
                    _keyboardJoystickListener.JoystickSouthButton += OnThirdKeyPressed;
                    _keyboardJoystickListener.JoystickNorthButton += OnFourthKeyPressed;
                    _keyboardJoystickListener.JoystickEastButton += OnFifthKeyPressed;
                    _keyboardJoystickListener.JoystickWestButton += OnSixthKeyPressed;
                }
                yield return null;
            }
        }

        // Keyboard Inputs
        private void OnFirstKeyPressed()
        {

        }
        private void OnSecondKeyPressed()
        {

        }
        private void OnThirdKeyPressed()
        {

        }
        private void OnFourthKeyPressed()
        {

        }
        private void OnFifthKeyPressed()
        {

        }
        private void OnSixthKeyPressed()
        {

        }

        // Joystick Inputs
        private void OnJoystickRightTwo()
        {

        }
        private void OnJoystickLeftTwo()
        {

        }
        private void OnJoystickSouthButton()
        {

        }
        private void OnJoystickNorthButton()
        {

        }
        private void OnJoystickEastButton()
        {

        }
        private void OnJoystickWestButton()
        {

        }
        
    }
}
