using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockStateMachine
{
    public BlockState CurrentState { get; private set; }

    public void Initialize(BlockState startingState) {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(BlockState newState) {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
