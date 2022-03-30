using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Integrator
{
    public static void ExplicitEuler(Body body, float dt)
    {
        body.position += body.velocity * dt;
        body.velocity += body.acceleration * dt;
    }
}
