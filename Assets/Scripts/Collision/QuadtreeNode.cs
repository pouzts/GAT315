using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadtreeNode
{
    AABB nodeAABB;
    int nodeCapacity;
    List<Body> nodeBodies = new List<Body>();

    QuadtreeNode northeast;
    QuadtreeNode northwest;
    QuadtreeNode southeast;
    QuadtreeNode southwest;

    bool subdivded = false;

    public QuadtreeNode(AABB aabb, int capacity)
    {
        nodeAABB = aabb;
        nodeCapacity = capacity;
    }

    public void Insert(Body body)
    {
        // check if with node
        if (!nodeAABB.Contains(body.shape.GetAABB(body.position))) return;

        // check if within capacity
        if (nodeBodies.Count < nodeCapacity)
        {
            nodeBodies.Add(body);
        }
        else
        { 
        
        }
    }
}
