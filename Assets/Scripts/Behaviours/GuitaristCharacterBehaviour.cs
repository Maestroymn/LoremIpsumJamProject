using System.Collections;
using Managers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Behaviours
{
    public class GuitaristCharacterBehaviour : MonoBehaviour
    {
        public CharacterSituation CharacterSituation;
        public float Angle;
        private bool _isMouseClaimed;
        private Vector2 _mouseDir;
        private float _vertical;
        Vector2 guitarLastPos, drumLastPos;
        public LayerMask layerMask;
        [SerializeField] private MouseListener mouseListener;
        [SerializeField] public Rigidbody2D Rigidbody2D;
        [SerializeField] private DrumCharacterBehaviour _drumCharacter;
        [SerializeField] private Animator _animator;
        [HideInInspector] public GuitarBubbleBehaviour currentBubble;
        [SerializeField] private BaseBossBehaviour boss;
        [SerializeField] public HealthManager _healthManager;
        public int guitaristMissInput;
        [SerializeField] private AudioClip _failEffect;
        [SerializeField] private AudioSource _audioSource, _mainAudioSource;
        private static readonly int Die = Animator.StringToHash("Die");
        [SerializeField] private UltimateComboManager ComboManager;
        private static readonly int Ulti1 = Animator.StringToHash("Ulti");
        private static readonly int FirstAttack = Animator.StringToHash("FirstAttack");

        public void Initialize()
        {
            _isMouseClaimed = true;
            mouseListener.LeftClick += OnLeftClick;
            mouseListener.RightClick += OnRightClick;
            mouseListener.LeftClickDraggedUp += OnLeftClickDragUp;
            mouseListener.LeftClickDraggedDown += OnLeftClickDragDown;
            mouseListener.RightClickDraggedUp += OnRightClickDragUp;
            mouseListener.RightClickDraggedDown += OnRightClickDragDown;
            _healthManager.OnDead += OnGuitaristDead;
            ComboManager.OnSuccess += Ulti;
            _mainAudioSource.Play();
        }

        private void Ulti()
        {
            ComboManager.OnSuccess -= Ulti;
            _animator.SetTrigger(Ulti1);
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
            //_drumCharacter.transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
            //transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
        }
        
        private void BubbleCorrectHit(GameObject bubbleObject)
        {
            LeanTween.scale(bubbleObject, new Vector3(2.5f, 2.5f, 2.5f), .1f).setOnComplete(() =>
            {
                Destroy(bubbleObject,.01f);
            });
        }

        // Mouse Inputs
        private void OnLeftClick(PointerEventData eventData)
        {
            if (currentBubble!=null && currentBubble.input == MouseInputs.LeftClick && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                BubbleCorrectHit(currentBubble.gameObject);
                HitDamage(5);
                ComboManager.ComboBarProgression();
            }
            else
            {
                DamageGuitarist();
                ComboManager.ComboFailed();
            }
        }

        private void OnRightClick(PointerEventData eventData)
        {
            if (currentBubble!=null && currentBubble.input == MouseInputs.RightClick && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                BubbleCorrectHit(currentBubble.gameObject);
                HitDamage(5);
                ComboManager.ComboBarProgression();
            }
            else
            {
                DamageGuitarist();
                ComboManager.ComboFailed();
            }
        }
    
        private void OnLeftClickDragUp(PointerEventData eventData)
        {
            if (currentBubble!=null && currentBubble.input == MouseInputs.LeftClickDragUp && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                BubbleCorrectHit(currentBubble.gameObject);
                HitDamage(5);
                ComboManager.ComboBarProgression();
            }
            else
            {
                DamageGuitarist();
                ComboManager.ComboFailed();
            }
        }

        private void OnLeftClickDragDown(PointerEventData eventData)
        {
            if (currentBubble!=null && currentBubble.input == MouseInputs.LeftClickDragDown && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                BubbleCorrectHit(currentBubble.gameObject);
                HitDamage(5);
                ComboManager.ComboBarProgression();
            }
            else
            {
                DamageGuitarist();
                ComboManager.ComboFailed();
            }
        }

        private void OnRightClickDragUp(PointerEventData eventData)
        {
            if (currentBubble!=null && currentBubble.input == MouseInputs.RightClickDragUp && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                BubbleCorrectHit(currentBubble.gameObject);
                HitDamage(5);
                ComboManager.ComboBarProgression();
            }
            else
            {
                ComboManager.ComboFailed();
                DamageGuitarist();
            }
        }

        private void OnRightClickDragDown(PointerEventData eventData)
        {
            
            if (currentBubble!=null&&currentBubble.input == MouseInputs.RightClickDragDown && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                BubbleCorrectHit(currentBubble.gameObject);
                HitDamage(5);
                ComboManager.ComboBarProgression();
            }
            else
            {
                DamageGuitarist();
                ComboManager.ComboFailed();
            }
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            guitarLastPos = transform.position;
            drumLastPos = _drumCharacter.transform.position;
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position), 1.5f, layerMask);
            if (hit.collider != null)
            {
                transform.position = guitarLastPos;
                _drumCharacter.transform.position = drumLastPos;
            }
        }

        private void HitDamage(int damage)
        {
            _animator.SetTrigger(FirstAttack);
            boss.damageTaken = damage;
            boss.DamageBoss();
        }

        public void DamageGuitarist()
        {
            _healthManager.SetHealth(guitaristMissInput,true);
            _mainAudioSource.volume=0.1f;
            _audioSource.clip=_failEffect;
            _audioSource.Play();
            _mainAudioSource.volume=0.2f;
        }
        
        private IEnumerator ContinueMusicAgain(float delay)
        {
            yield return new WaitForSeconds(delay);
            _mainAudioSource.volume=0.2f;
        }

        private void OnGuitaristDead()
        {
            CharacterSituation = CharacterSituation.Dead;
            mouseListener.LeftClick -= OnLeftClick;
            mouseListener.RightClick -= OnRightClick;
            mouseListener.LeftClickDraggedUp -= OnLeftClickDragUp;
            mouseListener.LeftClickDraggedDown -= OnLeftClickDragDown;
            mouseListener.RightClickDraggedUp -= OnRightClickDragUp;
            mouseListener.RightClickDraggedDown -= OnRightClickDragDown;
            _healthManager.OnDead -= OnGuitaristDead;
            _animator.SetTrigger(Die);
            gameObject.SetActive(false);
            boss.KillPlayer();
        }

    }
}
