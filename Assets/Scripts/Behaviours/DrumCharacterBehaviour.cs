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
        [SerializeField] private Animator _animator;
        [HideInInspector] public DrumBubbleBehaviour currentBubble;

        private float _vertical;
        private Vector3 _direction;
        private bool _isKeyboardClaimed;

        public CharacterSituation CharacterSituation;

        public void Initialize()
        {
            _isKeyboardClaimed = true;
            _keyboardListener.FirstKeyPressed += OnFirstKeyPressed;
            _keyboardListener.SecondKeyPressed += OnSecondKeyPressed;
            _keyboardListener.ThirdKeyPressed += OnThirdKeyPressed;
            _keyboardListener.FourthKeyPressed += OnFourthKeyPressed;
            _keyboardListener.FifthKeyPressed += OnFifthKeyPressed;
            _keyboardListener.SixthKeyPressed += OnSixthKeyPressed;
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

        // Keyboard Inputs
        private void OnFirstKeyPressed()
        {
            if (currentBubble.input == _keyboardListener.FirstKey && currentBubble._isInteractable && currentBubble!=null)
            {
                currentBubble._isInteractable = false;
                Debug.Log(currentBubble.input+" Pressed");
            }
        }
        private void OnSecondKeyPressed()
        {
            if (currentBubble.input == _keyboardListener.SecondKey && currentBubble._isInteractable && currentBubble!=null)
            {
                currentBubble._isInteractable = false;
                Debug.Log(currentBubble.input+" Pressed");
            }
        }
        private void OnThirdKeyPressed()
        {
            if (currentBubble.input == _keyboardListener.ThirdKey && currentBubble._isInteractable && currentBubble!=null)
            {
                currentBubble._isInteractable = false;
                Debug.Log(currentBubble.input+" Pressed");
            }
        }
        private void OnFourthKeyPressed()
        {
            if (currentBubble.input == _keyboardListener.FourthKey && currentBubble._isInteractable && currentBubble!=null)
            {
                currentBubble._isInteractable = false;
                Debug.Log(currentBubble.input+" Pressed");
            }
        }
        private void OnFifthKeyPressed()
        {
            if (currentBubble.input == _keyboardListener.FifthKey && currentBubble._isInteractable && currentBubble!=null)
            {
                currentBubble._isInteractable = false;
                Debug.Log(currentBubble.input+" Pressed");
            }
        }
        private void OnSixthKeyPressed()
        {
            if (currentBubble.input == _keyboardListener.SixthKey && currentBubble._isInteractable && currentBubble!=null)
            {
                currentBubble._isInteractable = false;
                Debug.Log(currentBubble.input+" Pressed");
            }
        }

    }
}
