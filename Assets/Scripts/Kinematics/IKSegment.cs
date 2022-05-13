using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKSegment : KinematicSegment
{
    public override void Initialize(KinematicSegment parent, Vector2 position, float angle, float length, float size)
    {
        this.parent = parent;
        this.size = size;
        this.angle = angle;
        this.length = length;

        start = position;
    }

    private void Update()
    {
        // scale segment

        // update rotation

    }

    public void Follow(Vector2 target)
    {
        // compute direction (target <- start) with segment length
        
        // convert direction cartesian to polar
        
        // set start to target - direction

    }
}
