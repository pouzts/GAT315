using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BVH : BroadPhase
{
    BVHNode rootNode;

    public override void Build(AABB aabb, List<Body> bodies)
    {
        queryResultCount = 0;
        List<Body> sorted = new List<Body>(bodies);

        // sort bodies along x-axis (position.x)
        sorted.Sort((body1, body2) => body1.position.x.CompareTo(body2.position.x));

        // create BVH root node
        rootNode = new BVHNode(sorted);
    }

    public override void Query(AABB aabb, List<Body> results)
    {
        rootNode.Query(aabb, results);
        // update result count
        queryResultCount = queryResultCount + results.Count;
    }

    public override void Query(Body body, List<Body> results)
    {
        rootNode.Query(body.shape.GetAABB(body.position), results);
    }

    public override void Draw()
    {
        rootNode?.Draw();
    }
}
