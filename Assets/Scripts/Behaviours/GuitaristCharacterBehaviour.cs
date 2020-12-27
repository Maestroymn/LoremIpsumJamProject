﻿using System.Collections;
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
        [SerializeField] private MouseListener mouseListener;
        [SerializeField] public Rigidbody2D Rigidbody2D;
        [SerializeField] private DrumCharacterBehaviour _drumCharacter;
        [SerializeField] private Animator _animator;
        [HideInInspector] public GuitarBubbleBehaviour currentBubble;
        [SerializeField] private BaseBossBehaviour boss;

        public void Initialize()
        {
            _isMouseClaimed = true;
            mouseListener.LeftClick += OnLeftClick;
            mouseListener.RightClick += OnRightClick;
            mouseListener.LeftClickDraggedUp += OnLeftClickDragUp;
            mouseListener.LeftClickDraggedDown += OnLeftClickDragDown;
            mouseListener.RightClickDraggedUp += OnRightClickDragUp;
            mouseListener.RightClickDraggedDown += OnRightClickDragDown;
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
            if (currentBubble.input == MouseInputs.LeftClick && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                Debug.Log("Mouse Clicked Btw");
            }
        }

        private void OnRightClick(PointerEventData eventData)
        {
            if (currentBubble.input == MouseInputs.RightClick && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                Debug.Log("Mouse 1 OnRightClick ");
            }
        }
    
        private void OnLeftClickDragUp(PointerEventData eventData)
        {
            if (currentBubble.input == MouseInputs.LeftClickDragUp && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                Debug.Log("Left Click Drag Up");
            }
        }

        private void OnLeftClickDragDown(PointerEventData eventData)
        {
            if (currentBubble.input == MouseInputs.LeftClickDragDown && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                Debug.Log("Left Click Drag Down");
            }
        }

        private void OnRightClickDragUp(PointerEventData eventData)
        {
            if (currentBubble.input == MouseInputs.RightClickDragUp && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                Debug.Log("right Click Drag Up");
            }
        }

        private void OnRightClickDragDown(PointerEventData eventData)
        {
            if (currentBubble.input == MouseInputs.RightClickDragDown && currentBubble._isInteractable)
            {
                currentBubble._isInteractable = false;
                Debug.Log("Right Click Drag Down");
            }
        }
        private void HitDamage(int damage)
        {
            boss.damageTaken = damage;
            boss.DamageBoss();
        }
    }
}
