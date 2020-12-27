using System.Collections;
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
        [SerializeField] private HealthManager _healthManager;
        [SerializeField] private int guitaristMissInput;
        [SerializeField] private AudioClip _failEffect;
        [SerializeField] private AudioSource _audioSource, _mainAudioSource;
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
            _mainAudioSource.Play();
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

        // Mouse Inputs
        private void OnLeftClick(PointerEventData eventData)
        {
            if (currentBubble!=null && currentBubble.input == MouseInputs.LeftClick && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                Debug.Log("Mouse Clicked Btw");
            }
            else
            {
                DamageGuitarist();
            }
        }

        private void OnRightClick(PointerEventData eventData)
        {
            if (currentBubble!=null && currentBubble.input == MouseInputs.RightClick && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                Debug.Log("Mouse 1 OnRightClick ");
            }
            else
            {
                DamageGuitarist();
            }
        }
    
        private void OnLeftClickDragUp(PointerEventData eventData)
        {
            if (currentBubble!=null && currentBubble.input == MouseInputs.LeftClickDragUp && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                Debug.Log("Left Click Drag Up");
            }
            else
            {
                DamageGuitarist();
            }
        }

        private void OnLeftClickDragDown(PointerEventData eventData)
        {
            if (currentBubble!=null && currentBubble.input == MouseInputs.LeftClickDragDown && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                Debug.Log("Left Click Drag Down");
            }
            else
            {
                DamageGuitarist();
            }
        }

        private void OnRightClickDragUp(PointerEventData eventData)
        {
            if (currentBubble!=null && currentBubble.input == MouseInputs.RightClickDragUp && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                Debug.Log("right Click Drag Up");
            }
            else
            {
                DamageGuitarist();
            }
        }

        private void OnRightClickDragDown(PointerEventData eventData)
        {
            
            if (currentBubble!=null&&currentBubble.input == MouseInputs.RightClickDragDown && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                Debug.Log("Right Click Drag Down");
            }
            else
            {
                DamageGuitarist();
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
            boss.damageTaken = damage;
            boss.DamageBoss();
        }

        public void DamageGuitarist()
        {
            _healthManager.SetHealth(guitaristMissInput);
            _mainAudioSource.volume=0.1f;
            _audioSource.clip=_failEffect;
            _audioSource.Play();
            StartCoroutine(ContinueMusicAgain(_failEffect.length/2));
        }
        
        private IEnumerator ContinueMusicAgain(float delay)
        {
            yield return new WaitForSeconds(delay);
            _mainAudioSource.volume=0.2f;
        }

        private void OnGuitaristDead()
        {
            _animator.SetTrigger("Die");
            boss.KillPlayer();
        }

    }
}
