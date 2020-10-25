using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallState
{
    protected Ball ball;
    protected BallStateMachine stateMachine;
    protected BallData ballData;

    protected bool isExitingState;

    protected float startTime;

    public BallState(Ball ball, BallStateMachine stateMachine, BallData ballData) {
        this.ball = ball;
        this.stateMachine = stateMachine;
        this.ballData = ballData;
    }

    public virtual void Enter() {
        DoChecks();
        startTime = Time.time;
        isExitingState = false;
    }

    public virtual void Exit() {
        isExitingState = true;
    }

    public virtual void LogicUpdate() {

    }

    public virtual void PhysicsUpdate() {
        DoChecks();
    }

    public virtual void DoChecks() { }
}
