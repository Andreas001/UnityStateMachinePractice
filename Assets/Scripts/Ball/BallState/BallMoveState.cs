using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveState : BallState {

    private bool hasBeenEjected;

    public BallMoveState(Ball ball, BallStateMachine stateMachine, BallData ballData) : base(ball, stateMachine, ballData) {
    }

    public override void DoChecks() {
        base.DoChecks();
    }

    public override void Enter() {
        base.Enter();

        hasBeenEjected = true;

        ball.Eject();
    }

    public override void Exit() {
        base.Exit();

        hasBeenEjected = false;
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        if(ball.transform.position.y < ball.deadZone.transform.position.y) {
            ball.PlayerGameobject.GetComponent<Player>().SetHealth(ball.PlayerGameobject.GetComponent<Player>().GetHealth() - 1);

            stateMachine.ChangeState(ball.AttachedToPlayerState);
        }

        if (hasBeenEjected) {
            ball.Moving();
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
