using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AABB
{
    public Vector2 center;
    public Vector2 size;
    public Vector2 extents { get { return size * 0.5f; } }

    public Vector2 min { get { return center - extents; } set { SetMinMax(value, max); } }
    public Vector2 max { get { return size + min; } set { SetMinMax(min, value); } }

    public AABB(Vector2 center, Vector2 size)
    {
        this.center = center;
        this.size = size;
    }

    public bool Contains(Vector2 point)
    {
        return Intersect(point, point);
    }

    public bool Contains(AABB aabb)
    {
        return Intersect(aabb.min, aabb.max);
    }

    public void SetMinMax(Vector2 min, Vector2 max)
    {
        size = max - min;
        center = min + extents;
    }

    public bool Intersect(Vector2 min, Vector2 max)
    {
        return min.x >= this.min.x && max.x <= this.max.x &&
               min.y >= this.min.x && max.y <= this.max.y;
    }

    public void Expand(Vector2 point)
    {
        SetMinMax(Vector2.Min(point, min), Vector2.Max(point, max));
    }

    public void Expand(AABB aabb)
    {
        SetMinMax(Vector2.Min(aabb.min, min), Vector2.Max(aabb.max, max));
    }

    public void Draw(Color color, float width = 0.5f)
    {
        Debug.DrawLine(min, max, color);
        Debug.DrawLine(max, min, color);
    }
}
