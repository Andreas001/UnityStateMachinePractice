using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRedState : BlockState {
    public BlockRedState(Block block, BlockStateMachine stateMachine, BlockData blockData) : base(block, stateMachine, blockData) {
    }

    public override void DoChecks() {
        base.DoChecks();
    }

    public override void Enter() {
        base.Enter();

        block.sr.sprite = blockData.redBlockSprite;
    }

    public override void Exit() {
        base.Exit();
    }

    public override void LogicUpdate() {
        base.LogicUpdate();

        if(gotHit) {
            block.gotHit = false;
            stateMachine.ChangeState(block.YellowState);
        }
    }

    public override void PhysicsUpdate() {
        base.PhysicsUpdate();
    }
}
