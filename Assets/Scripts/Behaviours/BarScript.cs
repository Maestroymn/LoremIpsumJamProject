using UnityEngine;

namespace Behaviours
{
    public class BarScript : MonoBehaviour
    {
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out GuitarBubbleBehaviour guitarBubble))
            {
                guitarBubble.OnHit();
            }
            if (collision.TryGetComponent(out DrumBubbleBehaviour drumBubble))
            {
                drumBubble.OnHit();
            }
        }
    }
}
