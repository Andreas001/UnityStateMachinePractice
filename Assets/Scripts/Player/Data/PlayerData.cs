using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Alive State")]
    public int health = 1;

    [Header("Move State")]
    public float movementVelocity = 10f;
}
