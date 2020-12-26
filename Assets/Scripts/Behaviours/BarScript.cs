using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Behaviours
{
    public class BarScript : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out GuitarBubbleBehaviour guitarBubble))
            {
                //Debug.Log(collision.name + " OnStay");
                guitarBubble.OnHit();
            }
            if (collision.TryGetComponent(out DrumBubbleBehaviour drumBubble))
            {
                drumBubble.OnHit();
            }
        }
    }
}
