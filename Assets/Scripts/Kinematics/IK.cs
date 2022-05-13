using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK : MonoBehaviour
{
    [SerializeField] IKSegment prefabSegment;
    [SerializeField] int segmentCount = 5;
    [SerializeField] [Range(0.1f, 3.0f)] float size = 1;
    [SerializeField] [Range(0.1f, 3.0f)] float length = 1;

    [SerializeField] Transform targetTransform;
    [SerializeField] Transform anchor;

    List<IKSegment> segments = new List<IKSegment>();

    private void Start()
    {
        KinematicSegment parent = null;

        // create segments
        for (int i = 0; i < segmentCount; i++)
        {
            // create segment

            // add segment

            // set parent to current segment
        }
    }

    void Update()
    {
        // update segments
        foreach (var segment in segments)
        {
            // update size and length

            // set target to parent start if parent exists else set target to target transform position
            // Vector2 target = 

            // call segment follow with target as parameter
            
        }

        // if anchor is present
        if (anchor != null)
        {
            // start at the base (last segment = segment count - 1) 
            // int base_index = 
            // set base segment start to anchor position
            
            // iterate from the back to the front, setting segment start to next segment end
            /*for (int i = base_index - 1; i >= 0; i--)
            {
                segments[i].start = segments[i + 1].end;
            }*/
        }
    }

}
