using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    [SerializeField] private List<GameObject> bubbles;
    [SerializeField] private float bubbleSpeed;

    private void Update()
    {
        foreach (var item in bubbles)
        {
            item.transform.position += new Vector3(transform.position.x + bubbleSpeed * Time.deltaTime, transform.position.y,transform.position.z);
        }
    }
}
