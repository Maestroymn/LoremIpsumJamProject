using System;
using System.Collections.Generic;
using Behaviours;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputSystem
{
    public class MainMenuInputListener : MonoBehaviour,IDragHandler,IPointerDownHandler,IPointerEnterHandler,IPointerUpHandler
    {
        [SerializeField] private List<MainMenuSoundBarBehaviour> _soundBars;
        public event Action Dragged;
        public event Action Clicked;
        public event Action Enter;
        public event Action Released;

        private void Awake()
        {
            _soundBars.ForEach(soundbar =>
            {
                Dragged += soundbar.ChangeBarScale;
                Clicked += soundbar.ChangeBarScale;
                //Enter += soundbar.SongPlay;
                Released += soundbar.ChangeBarScale;
            });
        }

        public void StopListeningForMainMenuInput()
        {
            _soundBars.ForEach(soundbar =>
            {
                Dragged -= soundbar.ChangeBarScale;
                Clicked -= soundbar.ChangeBarScale;
                Enter -= soundbar.SongPlay;
                Released -= soundbar.ChangeBarScale;
            });
        }

        public void OnDrag(PointerEventData eventData)
        {
            Dragged?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Clicked?.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Enter?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Released?.Invoke();
        }
    }
}
