using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMovement : Movement
{

    NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); 
    }

    void Update()
    {
        navMeshAgent.speed = speedMax;
        navMeshAgent.angularSpeed = turnRate;
    }

    public override void ApplyForce(Vector3 force)
    {
        //
    }

    public override void MoveTowards(Vector3 target)
    {
        navMeshAgent.SetDestination(target);
    }

    public override void Stop()
    {
        navMeshAgent.isStopped = true;
    }
    public override Vector3 Velocity
    {
        get { return navMeshAgent.velocity; }
        set { navMeshAgent.velocity = value; }
    }

}
