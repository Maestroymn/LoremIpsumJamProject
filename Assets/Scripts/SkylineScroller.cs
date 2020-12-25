using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkylineScroller : MonoBehaviour
{

    [SerializeField] float skylineScrollSpeed = 0.2f;
    Material myMaterial;
    Vector2 offset;

    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        offset = new Vector2(skylineScrollSpeed, 0f);
    }

    void Update()
    {
        myMaterial.mainTextureOffset += offset * Time.deltaTime;
    }
}
