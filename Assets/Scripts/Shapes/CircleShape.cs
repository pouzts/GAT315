using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShape : Shape
{
    public override float size 
    { 
        get => transform.localScale.x; 
        set => transform.localScale = Vector2.one * value; 
    }

    public override float area => Mathf.PI * radius * radius;

    public float radius => size / 2;

    public override AABB GetAABB(Vector2 position)
    {
        return new AABB(position, size * Vector2.one);
    }
}