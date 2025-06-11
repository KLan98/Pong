using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private bool isMoving = false;

    public IdleState(StateMachine stateMachine, PlayerControl playerControl) : base(stateMachine, playerControl)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void PhysicsUpdate()
    {
        playerControl.rb.velocity = new Vector2(0, 0);
    }

    public override void InputUpdate()
    {
        if(playerControl.playerInputActions.Player.Down.IsPressed() || playerControl.playerInputActions.Player.Up.IsPressed())
        {
            isMoving = true;
        }

        else
        {
            isMoving = false;
        }
    }

    public override void LogicUpdate()
    {
        if (isMoving)
        {
            playerControl.playerSM.ChangeState(playerControl.moveState);
        }
    }
}
