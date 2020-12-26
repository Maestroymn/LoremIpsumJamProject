using System.Collections;
using UnityEngine;

namespace Behaviours
{
    public class DrumCharacterBehaviour : MonoBehaviour
    {
        float _vertical;
        [SerializeField] float movementSpeed = 50;
        Rigidbody2D drummerRigidBody;
        [SerializeField] GameObject secondPlayer;
        Vector2 _mouseDir;
        float _angle;
        Vector3 _direction;

        private bool _isJoystickClaimed, _isJoystickPressed, _isKeyboardClaimed;
        JoystickInputs joystickInputs;
        private void Awake()
        {
            drummerRigidBody = GetComponent<Rigidbody2D>();

            joystickInputs = new JoystickInputs();
            StartCoroutine(DrummerSelectInputs());

            joystickInputs.KeyboardJoystick.SouthButton.performed += ctx => SelectJoystickKeyboard();
            joystickInputs.KeyboardJoystick.SouthButton.canceled += ctx => SelectJoystickKeyboard();
        }
        private void FixedUpdate()
        {
            LookAtMouse();
            MovementBehaviour();
            Debug.Log(Input.mousePosition+"   " + transform.position);
        }

        void LookAtMouse()
        {
            _mouseDir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            _angle = Mathf.Atan2(_mouseDir.y, _mouseDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);

            secondPlayer.transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
        }

        void MovementBehaviour()
        {

            _vertical = Input.GetAxis("Vertical");
            Vector3 _newAngle = new Vector2(Mathf.Cos(_angle * Mathf.PI / 180f), Mathf.Sin(_angle * Mathf.PI / 180f));
            _direction = _vertical * _newAngle;

            if (Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) < 0.2f)
            {
                _direction = Vector3.zero;
            }
            drummerRigidBody.velocity = _direction * movementSpeed * Time.deltaTime;

            secondPlayer.GetComponent<Rigidbody2D>().velocity = _direction * movementSpeed * Time.deltaTime;
        }

        private IEnumerator DrummerSelectInputs()
        {
            while (true)
            {
                if (Input.GetKeyDown(KeyCode.Space) && !_isKeyboardClaimed)
                {
                    _isKeyboardClaimed = true;
                    _isJoystickClaimed = false;
                    _isJoystickPressed = false;
                }

                if (_isJoystickPressed && !_isJoystickClaimed)
                {
                    _isJoystickClaimed = true;
                    _isKeyboardClaimed = false;
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

        private void SelectJoystickKeyboard()
        {
            if (joystickInputs.KeyboardJoystick.SouthButton.triggered && !_isJoystickClaimed)
            {
                _isJoystickPressed = true;
                Debug.Log("Joystick");
            }
        }

        private void OnEnable()
        {
            joystickInputs.MouseJoystick.Enable();
        }

        private void OnDisable()
        {
            joystickInputs.MouseJoystick.Disable();
        }
    }
}
