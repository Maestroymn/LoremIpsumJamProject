using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class BubbleController : MonoBehaviour
    {
        [SerializeField] public List<GameObject> bubbles;
        [SerializeField] public float bubbleSpeed;

        private void Update()
        {
            if(bubbles.Count!=0)
            {
                foreach (var item in bubbles)
                {
                    item.transform.position += new Vector3(transform.position.x + bubbleSpeed * Time.deltaTime,
                        transform.position.y, transform.position.z);
                }
            }
        }
    }
}
