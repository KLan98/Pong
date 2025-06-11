using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State currentState;

    public void InitState(State initialState)
    {
        currentState = initialState;
        currentState.Enter();
    }

    public void ChangeState(State changeState)
    {
        currentState.Exit();
        currentState = changeState;
        currentState.Enter();
    }
}
