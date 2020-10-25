using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDieState : AliveState {
    public PlayerDieState(Player player, PlayerStateMachine stateMachine, PlayerData playerData) : base(player, stateMachine, playerData) {
    }
}
