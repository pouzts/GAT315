using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class UVScroll : MonoBehaviour
{
    [SerializeField] Vector2 scrollSpeed;
    MeshRenderer meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        Vector2 offset = Time.time * scrollSpeed;
        meshRenderer.material.SetTextureOffset("_MainTex", offset);
    }
}
