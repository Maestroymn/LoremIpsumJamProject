using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviours
{
    public class DrumBubbleBehaviour : MonoBehaviour
    {
        public KeyCode input;
        public DrumCharacterBehaviour drummer;
        public bool _isInteractable = true;

        public void OnHit()
        {
            drummer.currentBubble = this;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            _isInteractable = false;
            LeanTween.scale(gameObject, Vector3.zero, .2f).setOnComplete(() =>
            {
                Destroy(gameObject);
            });
        }

    }
}
