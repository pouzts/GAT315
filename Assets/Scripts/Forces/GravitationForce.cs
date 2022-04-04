using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationForce : Force
{
    [SerializeField] FloatData gravitation;

    public override void ApplyForce(List<Body> bodies)
    {
        throw new System.NotImplementedException();
    }
}
