using System.Collections;
using InputSystem;
using Managers;
using UnityEngine;

namespace Behaviours
{
    public enum CharacterSituation
    {
        OnMap,
        OnArena,
        Dead
    }
    public class DrumCharacterBehaviour : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 50;
        [SerializeField] private GuitaristCharacterBehaviour _guitaristCharacter;
        [SerializeField] public Rigidbody2D DrummerRigidBody;
        [SerializeField] private KeyboardListener _keyboardListener;
        [SerializeField] private Animator _animator;
        [HideInInspector] public DrumBubbleBehaviour currentBubble;
        [SerializeField] private BaseBossBehaviour boss;
        [SerializeField] private HealthManager _healthManager;
        [SerializeField] private int drummerMissInput;
        [SerializeField] private AudioClip _failEffect;
        [SerializeField] private AudioSource _audioSource, _mainAudioSource;
        [SerializeField] private UltimateComboManager ComboManager;
        [SerializeField] private Animator _Laseranimator;
        
        private float _vertical;
        private Vector3 _direction;
        private bool _isKeyboardClaimed;
        Vector2 guitarLastPos, drumLastPos;
        public LayerMask layerMask;

        private float counter;

        public CharacterSituation CharacterSituation;
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int Ulti1 = Animator.StringToHash("Ulti");
        private static readonly int Laser = Animator.StringToHash("Laser");

        public void Initialize()
        {
            _isKeyboardClaimed = true;
            _keyboardListener.FirstKeyPressed += OnFirstKeyPressed;
            _keyboardListener.SecondKeyPressed += OnSecondKeyPressed;
            _keyboardListener.ThirdKeyPressed += OnThirdKeyPressed;
            _keyboardListener.FourthKeyPressed += OnFourthKeyPressed;
            _keyboardListener.FifthKeyPressed += OnFifthKeyPressed;
            _keyboardListener.SixthKeyPressed += OnSixthKeyPressed;
            _healthManager.OnDead += OnDrummerDead;
            ComboManager.OnSuccess += Ulti;
            _mainAudioSource.Play();
        }
        
        private void FixedUpdate()
        {
            if(CharacterSituation==CharacterSituation.OnMap)
            {
                MovementBehaviour();
            }
        }

        private void Ulti()
        {
            ComboManager.OnSuccess -= Ulti;
            _animator.SetTrigger(Ulti1);
        }

        void MovementBehaviour()
        {
            _vertical = Input.GetAxisRaw("Vertical");
            Vector3 _newAngle = new Vector2(Mathf.Cos(_guitaristCharacter.Angle * Mathf.PI / 180f), Mathf.Sin(_guitaristCharacter.Angle * Mathf.PI / 180f));
            _direction = _vertical * _newAngle;
            if (!(Camera.main is null) && Vector2.Distance(transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition)) < 4f)
            {
                _direction = Vector3.zero;
            }

            DrummerRigidBody.velocity = _direction * movementSpeed * Time.deltaTime;
            _guitaristCharacter.Rigidbody2D.velocity = _direction * movementSpeed * Time.deltaTime;
        }

        private void BubbleCorrectHit(GameObject bubbleObject)
        {
            LeanTween.scale(bubbleObject, new Vector3(2.5f, 2.5f, 2.5f), .1f).setOnComplete(() =>
            {
                Destroy(bubbleObject,.01f);
            });
        }
        
        private void HitDamage(int damage)
        {
            _Laseranimator.SetTrigger(Laser);
            boss.damageTaken = damage;
            boss.DamageBoss();
        }
        
        // Keyboard Inputs
        private void OnFirstKeyPressed()
        {
            if (currentBubble!=null&&currentBubble.input == _keyboardListener.FirstKey && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                BubbleCorrectHit(currentBubble.gameObject);
                HitDamage(3);
                DrummerBuffSpells();
            }
            else
            {
                ComboManager.ComboFailed();
                counter--;
                DamageDrummer();
            }
        }
        private void OnSecondKeyPressed()
        {
            if (currentBubble!=null&&currentBubble.input == _keyboardListener.SecondKey && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                BubbleCorrectHit(currentBubble.gameObject);
                HitDamage(3);
                DrummerBuffSpells();
            }
            else
            {
                ComboManager.ComboFailed();
                counter--;
                DamageDrummer();
            }
        }
        private void OnThirdKeyPressed()
        {
            if ( currentBubble!=null&&currentBubble.input == _keyboardListener.ThirdKey && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                BubbleCorrectHit(currentBubble.gameObject);
                HitDamage(3);
                DrummerBuffSpells();
                ComboManager.ComboBarProgression();
            }
            else
            {
                ComboManager.ComboFailed();
                counter--;
                DamageDrummer();
            }
        }
        private void OnFourthKeyPressed()
        {
            if (currentBubble!=null&&currentBubble.input == _keyboardListener.FourthKey && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                BubbleCorrectHit(currentBubble.gameObject);
                HitDamage(3);
                DrummerBuffSpells();
                ComboManager.ComboBarProgression();
            }
            else
            {
                ComboManager.ComboFailed();
                counter--;
                DamageDrummer();
            }
        }
        
        private void OnFifthKeyPressed()
        {
            if (currentBubble!=null&&currentBubble.input == _keyboardListener.FifthKey && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                BubbleCorrectHit(currentBubble.gameObject);
                HitDamage(3);
                DrummerBuffSpells();
                ComboManager.ComboBarProgression();
            }
            else
            {
                ComboManager.ComboFailed();
                counter--;
                DamageDrummer();
            }
        }
        private void OnSixthKeyPressed()
        {
            if (currentBubble!=null&&currentBubble.input == _keyboardListener.SixthKey && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                BubbleCorrectHit(currentBubble.gameObject);
                HitDamage(3);
                DrummerBuffSpells();
                ComboManager.ComboBarProgression();
            }
            else
            {
                ComboManager.ComboFailed();
                counter--;
                DamageDrummer();
            }
        }

        private void DrummerBuffSpells()
        {
            counter++;
            if (counter % 4 == 0)
            {
                Debug.Log("Heal");
                _animator.SetTrigger("Heal");
                _healthManager.SetHealth(3, false);
                _guitaristCharacter._healthManager.SetHealth(3, false);
            }
            if (counter % 6 == 0)
            {
                Debug.Log("Shield");
                _animator.SetTrigger("Shield");
                drummerMissInput -= 1;
                _guitaristCharacter.guitaristMissInput -= 1;
                _animator.SetTrigger("Glow");
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            guitarLastPos = _guitaristCharacter.transform.position;
            drumLastPos = transform.position;
        }
        
        private void OnCollisionStay2D(Collision2D collision)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position), 1.5f, layerMask);
            if(hit.collider != null)
            {
                transform.position = drumLastPos;
                _guitaristCharacter.transform.position = guitarLastPos;
            }
        }

        public void DamageDrummer()
        {
            _healthManager.SetHealth(drummerMissInput, true);
            _mainAudioSource.volume = 0.1f;
            _audioSource.clip = _failEffect;
            _audioSource.Play();
            _mainAudioSource.volume = 0.2f;
        }

        private IEnumerator ContinueMusicAgain(float delay)
        {
            yield return new WaitForSeconds(delay);
            _mainAudioSource.volume=0.2f;
        }

        private void OnDrummerDead()
        {
            _healthManager.OnDead -= OnDrummerDead;
            CharacterSituation = CharacterSituation.Dead;
            _animator.SetTrigger(Die);
            _keyboardListener.FirstKeyPressed -= OnFirstKeyPressed;
            _keyboardListener.SecondKeyPressed -= OnSecondKeyPressed;
            _keyboardListener.ThirdKeyPressed -= OnThirdKeyPressed;
            _keyboardListener.FourthKeyPressed -= OnFourthKeyPressed;
            _keyboardListener.FifthKeyPressed -= OnFifthKeyPressed;
            _keyboardListener.SixthKeyPressed -= OnSixthKeyPressed;
            gameObject.SetActive(false);
            boss.KillPlayer();
        }

    }


}
