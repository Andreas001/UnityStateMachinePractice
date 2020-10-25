using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockYellowState : BlockState {
    public BlockYellowState(Block block, BlockStateMachine stateMachine, BlockData blockData) : base(block, stateMachine, blockData) {
    }

    public override void DoChecks() {
        base.DoChecks();
    }

    public override void Enter() {
        base.Enter();
        gotHit = false;

        block.sr.sprite = blockData.yellowBlockSprite;
    }

    public override void Exit() {
        base.Exit();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        if (gotHit) {
            block.gotHit = false;
            stateMachine.ChangeState(block.GreenState);
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
