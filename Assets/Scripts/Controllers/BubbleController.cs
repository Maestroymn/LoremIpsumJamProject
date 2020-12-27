using System.Collections.Generic;
using Behaviours;
using UnityEngine;

namespace Controllers
{
    public class BubbleController : MonoBehaviour
    {
        public List<DrumBubbleBehaviour> DrummerBubbles;
        public List<GuitarBubbleBehaviour> GuitarBubbles;
        [SerializeField] public float bubbleSpeed;

        private void Update()
        {
            if(DrummerBubbles.Count!=0)
            {
                DrummerBubbles.ForEach(x=>
                {
                    if (x != null)
                    {
                        x.transform.localPosition+=Time.deltaTime*Vector3.right*bubbleSpeed;
                    }
                });
            }
            if(GuitarBubbles.Count!=0)
            {
                GuitarBubbles.ForEach(x=>
                {
                    if (x != null)
                    {
                        x.transform.localPosition+=Time.deltaTime*Vector3.right*bubbleSpeed;
                    }
                });
            }
        }
    }
}
