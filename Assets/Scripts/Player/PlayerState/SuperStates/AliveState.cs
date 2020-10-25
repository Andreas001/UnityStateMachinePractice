using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliveState : PlayerState {

    protected int xInput;

    protected int currentPlayerHealth = 1;

    public AliveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData) {
    }

    public override void DoChecks() {
        base.DoChecks();
    }

    public override void Enter() {
        base.Enter();

        currentPlayerHealth = playerData.health;
    }

    public override void Exit() {
        base.Exit();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        xInput = player.InputHanlder.NormalizeInputX;

        if (currentPlayerHealth <= 0) {
            stateMachine.ChangeState(player.DieState);
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
