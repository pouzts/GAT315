using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationForce : Force
{
    [SerializeField] FloatData gravitation;

    public override void ApplyForce(List<Body> bodies)
    {
        for (int i = 0; i < bodies.Count - 1; i++)
        {
            for (int j = i + 1; j < bodies.Count; j++)
            {
                Body bodyA = bodies[i];
                Body bodyB = bodies[j];

                // apply gravitational force
                Vector2 direction = bodyA.position - bodyB.position;
                float distanceSqr = Mathf.Max(direction.sqrMagnitude, 1); //d^2
                float force = gravitation.value * (bodyA.mass * bodyB.mass) / distanceSqr; //G(m1*m2/d^2)

                bodyA.ApplyForce(-direction.normalized * force, Body.eForceMode.Force);
                bodyB.ApplyForce( direction.normalized * force, Body.eForceMode.Force);
            }
        }
    }
}