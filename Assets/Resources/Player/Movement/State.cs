using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    private StateMachine stateMachine;
    public PlayerControl playerControl;
    public State(StateMachine stateMachine, PlayerControl playerControl)
    {
        this.stateMachine = stateMachine;
        this.playerControl = playerControl;
    }

    public virtual void Enter()
    {
        //Debug.Log("Enter " + this);
    }

    public virtual void Exit()
    {
        //Debug.Log("Exit " + this);
    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void InputUpdate()
    {

    }
}
