using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBehavior : Behavior
{
    public float displacement = 10.0f;
    public float radius = 10.0f;
    public float distance = 10.0f;
    private float angle = 30.0f;

    public override Vector3 Execute()
    {
        Vector3 force = Vector3.zero;
        // code here :)
        angle = angle + Random.Range(-displacement, displacement);
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        Vector3 point = rotation * Vector3.forward * radius;

        Vector3 forward = Agent.Direction * distance;
        Vector3 direction = (forward + point).normalized;
        Vector3 desired = direction * Agent.maxSpeed;
        force = Vector3.ClampMagnitude(desired - Agent.Velocity, Agent.maxForce);

        Debug.DrawLine(transform.position, transform.position + forward, Color.yellow);
        Debug.DrawLine(transform.position + forward, transform.position + forward + point, Color.yellow);

        Debug.DrawRay(transform.position, desired, Color.red); // desired
        Debug.DrawRay(transform.position + Agent.Velocity, force, Color.green); // steering

        return force;
    }

}
