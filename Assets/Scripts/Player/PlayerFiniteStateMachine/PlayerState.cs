﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    protected bool isExitingState;

    protected float startTime;  
    
    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
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
