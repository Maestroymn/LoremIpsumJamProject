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
        [SerializeField] private float beatTempo;
        [SerializeField] private float bpm;

        private void Start()
        {
            beatTempo = beatTempo / bpm;
        }

        private void Update()
        {
            if(DrummerBubbles.Count!=0)
            {
                DrummerBubbles.ForEach(x=>
                {
                    if (x != null)
                    {
                        x.transform.localPosition+=Time.deltaTime*Vector3.right*beatTempo;
                    }
                });
            }
            if(GuitarBubbles.Count!=0)
            {
                GuitarBubbles.ForEach(x=>
                {
                    if (x != null)
                    {
                        x.transform.localPosition+=Time.deltaTime*Vector3.right*beatTempo;
                    }
                });
            }
        }
    }
}
