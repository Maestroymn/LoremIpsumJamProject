using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform drummer;
    Vector3 speed;
    public float smoothDampValue;
    public bool isFollowing;
    
    void FixedUpdate()
    {
        if(isFollowing)
        {
            var targetPos = drummer.TransformPoint(new Vector3(0, 0, -10));
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref speed, smoothDampValue);
        }
    }
}
