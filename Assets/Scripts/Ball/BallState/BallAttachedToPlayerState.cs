using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallAttachedToPlayerState : BallState {

    private bool ejectInput;

    public BallAttachedToPlayerState(Ball ball, BallStateMachine stateMachine, BallData ballData) : base(ball, stateMachine, ballData) {
    }

    public override void DoChecks() {
        base.DoChecks();
    }

    public override void Enter() {
        base.Enter();

        ball.SetVelocityZero();
        ball.gameObject.transform.parent = ball.PlayerGameobject.transform;
        ball.gameObject.transform.localPosition = new Vector3(0f, 0.5f, 0f);
    }

    public override void Exit() {
        base.Exit();

        ball.gameObject.transform.parent = null;
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        ball.gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);

        ball.gameObject.transform.localPosition = new Vector3(0f, 1f, 0f);

        ejectInput = ball.InputHanlder.EjectInput;

        if(ejectInput) {
            stateMachine.ChangeState(ball.MoveState);
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
