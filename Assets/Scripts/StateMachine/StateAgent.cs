using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class StateAgent : Agent
{
    public StateMachine StateMachine { get; private set; }

    private void Start()
    {
        StateMachine = GetComponent<StateMachine>();
    }

    private void Update()
    {
        animator.SetFloat("Speed", movement.Velocity.magnitude);
        StateMachine.Execute();
    }
}
