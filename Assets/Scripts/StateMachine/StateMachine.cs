using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State CurrentState { get; set; }
    // Start is called before the first frame update
    public void Initialize(State startState)
    {
        CurrentState = startState;
        CurrentState.Enter();
    }

    // Update is called once per frame
    public void ChangeState(State newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
