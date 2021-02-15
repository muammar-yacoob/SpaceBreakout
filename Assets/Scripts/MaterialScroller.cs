using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScroller : MonoBehaviour
{
    private Renderer rend;
    [SerializeField] [Range(-2, 2)] float scrollSpeed = 0.5f;


    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.mainTextureOffset = Vector2.up * offset;
    }
}
