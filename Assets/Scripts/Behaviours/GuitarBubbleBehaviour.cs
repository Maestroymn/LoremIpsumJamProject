using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviours
{
    public enum MouseInputs
    {
        LeftClick,
        LeftClickDragUp,
        LeftClickDragDown,
        RightClick,
        RightClickDragUp,
        RightClickDragDown,
    }
    public class GuitarBubbleBehaviour : MonoBehaviour
    {
        public MouseInputs input;
        public GuitaristCharacterBehaviour guitarist;
        public bool _isInteractable = true;
        
        public void OnHit()
        {
            guitarist.currentBubble = this;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _isInteractable = false;
            LeanTween.scale(gameObject, Vector3.zero, .2f).setOnComplete(() =>
            {
                guitarist.DamageGuitarist();
                Destroy(gameObject);
            });
        }

    }
}
