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
        // sort bodies by the body's x position
        List<Body> sorted = bodies.OrderBy(body => (body.position.x)).ToList();

        // create bvh root node
        rootNode = new BVHNode(sorted, 0);
    }

    public override void Query(AABB aabb, List<Body> results)
    {
        rootNode.Query(aabb, results);
        // update result count
        queryResultCount += results.Count;
    }

    public override void Query(Body body, List<Body> results)
    {
        rootNode.Query(body.shape.GetAABB(body.position), results);
        queryResultCount += results.Count;
    }

    public override void Draw()
    {
        rootNode?.Draw();
    }
}
