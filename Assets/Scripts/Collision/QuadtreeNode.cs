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

    bool subdivided = false;

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
            // exceeded capacity, subdivide node
            if (!subdivided) Subdivide();

            // insert body into the newly subdivided nodes
            northeast.Insert(body);
            northwest.Insert(body);
            southeast.Insert(body);
            southwest.Insert(body);
        }
    }

    private void Subdivide()
    {
        float xo = nodeAABB.extents.x * 0.5f;
        float yo = nodeAABB.extents.y * 0.5f;

        northeast = new QuadtreeNode(new AABB(new Vector2(nodeAABB.center.x - xo, nodeAABB.center.y + yo), nodeAABB.extents), nodeCapacity);
        northwest = new QuadtreeNode(new AABB(new Vector2(nodeAABB.center.x + xo, nodeAABB.center.y + yo), nodeAABB.extents), nodeCapacity);
        southeast = new QuadtreeNode(new AABB(new Vector2(nodeAABB.center.x - xo, nodeAABB.center.y - yo), nodeAABB.extents), nodeCapacity);
        southwest = new QuadtreeNode(new AABB(new Vector2(nodeAABB.center.x + xo, nodeAABB.center.y - yo), nodeAABB.extents), nodeCapacity);

        subdivided = true;
    }

    public void Draw()
    {
        nodeAABB.Draw(Color.green);

        // draw northeast node
        northeast?.nodeAABB.Draw(Color.green);
        // draw northwest node
        northwest?.nodeAABB.Draw(Color.green);
        // draw southeast node
        southeast?.nodeAABB.Draw(Color.green);
        // draw southwest node
        southwest?.nodeAABB.Draw(Color.green);
    }
}
