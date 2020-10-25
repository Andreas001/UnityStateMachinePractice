using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newBallData", menuName = "Data/Ball Data/Base Data")]
public class BallData : ScriptableObject {

    [Header("Move State")]
    public float minimumSpeed = 10f;
    public float maximumSpeed = 20f;
    public float movementVelocity = 10f;
    public float minimumVerticalMovement = 0.1f;
    public Vector2 angle;
}
