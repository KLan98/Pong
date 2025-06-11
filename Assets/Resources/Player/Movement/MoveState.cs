using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    private bool isIdle = false;
    private Vector2 forceDirection;
    private float maxMagnitude = 12f;

    public MoveState(StateMachine stateMachine, PlayerControl playerControl) : base(stateMachine, playerControl)
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
        playerControl.rb.AddForce(playerControl.transform.up * forceDirection, ForceMode2D.Impulse);

        // clamp velocity
        if (playerControl.rb.velocity.sqrMagnitude > maxMagnitude)
        {
            playerControl.rb.velocity = Vector2.ClampMagnitude(playerControl.rb.velocity, maxMagnitude);
        }
    }

    public override void InputUpdate()
    {
        if (playerControl.playerInputActions.Player.Down.IsPressed())
        {
            isIdle = false;
            forceDirection = -Vector2.up;
        }

        else if (playerControl.playerInputActions.Player.Up.IsPressed())
        {
            isIdle = false;
            forceDirection = Vector2.up;
        }

        else
        {
            isIdle = true;
        }
    }

    public override void LogicUpdate()
    {
        if (isIdle)
        {
            playerControl.playerSM.ChangeState(playerControl.idleState);
        }
    }
}
