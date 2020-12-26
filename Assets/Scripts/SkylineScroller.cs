using System.Collections;
using System.Collections.Generic;
using Behaviours;
using UnityEngine;

public class SkylineScroller : MonoBehaviour
{

    [SerializeField] float skylineScrollSpeed = 0.2f;
    [SerializeField] private Material myMaterial;
    private Vector2 _offset;

    public void Initialize()
    {
        _offset = new Vector2(skylineScrollSpeed, 0f);
    }

    void Update()
    {
        myMaterial.mainTextureOffset += _offset * Time.deltaTime;
    }
}
