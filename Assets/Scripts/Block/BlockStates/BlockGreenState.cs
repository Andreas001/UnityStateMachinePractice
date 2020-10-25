using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGreenState : BlockState {
    public BlockGreenState(Block block, BlockStateMachine stateMachine, BlockData blockData) : base(block, stateMachine, blockData) {
    }

    public override void DoChecks() {
        base.DoChecks();
    }

    public override void Enter() {
        base.Enter();
        gotHit = false;

        block.sr.sprite = blockData.greenBlockSprite;
    }

    public override void Exit() {
        base.Exit();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        if (gotHit) {
            block.gotHit = false;
            stateMachine.ChangeState(block.DeadState);
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
