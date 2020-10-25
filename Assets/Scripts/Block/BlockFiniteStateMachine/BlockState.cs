using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockState
{
    protected Block block;
    protected BlockStateMachine stateMachine;
    protected BlockData blockData;

    protected bool isExitingState;
    protected bool gotHit;

    protected float startTime;

    public BlockState(Block block, BlockStateMachine stateMachine, BlockData blockData) {
        this.block = block;
        this.stateMachine = stateMachine;
        this.blockData = blockData;
    }

    public virtual void Enter() {
        DoChecks();
        startTime = Time.time;
        isExitingState = false;
        gotHit = false;
    }

    public virtual void Exit() {
        isExitingState = true;
    }

    public virtual void LogicUpdate() {
        gotHit = block.gotHit;
    }

    public virtual void PhysicsUpdate() {
        DoChecks();
    }

    public virtual void DoChecks() { }
}
