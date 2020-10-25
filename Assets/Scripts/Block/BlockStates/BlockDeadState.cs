using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDeadState : BlockState {
    public BlockDeadState(Block block, BlockStateMachine stateMachine, BlockData blockData) : base(block, stateMachine, blockData) {
    }

    public override void DoChecks() {
        base.DoChecks();
    }

    public override void Enter() {
        base.Enter();

        block.gameObject.SetActive(false);
    }

    public override void Exit() {
        base.Exit();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
