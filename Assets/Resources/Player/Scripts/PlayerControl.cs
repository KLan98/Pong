using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public StateMachine playerSM;
    public MoveState moveState;
    public IdleState idleState;
    public PlayerInputActions playerInputActions;
    public Rigidbody2D rb;

    private void Awake()
    {
        playerSM = new StateMachine();
        idleState = new IdleState(playerSM, this);
        moveState = new MoveState(playerSM, this);

        playerSM.InitState(idleState);

        LoadInputActions();
        LoadRigidBody2D();
    }

    private void FixedUpdate()
    {
        playerSM.currentState.PhysicsUpdate();
        //Debug.Log($"Velocity = {rb.velocity}");
    }

    private void Update()
    {
        playerSM.currentState.InputUpdate();
        playerSM.currentState.LogicUpdate();
    }

    private void LoadInputActions()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    private void LoadRigidBody2D()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
}
