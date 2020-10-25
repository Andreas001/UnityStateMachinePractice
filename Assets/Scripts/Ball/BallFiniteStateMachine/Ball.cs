using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    #region State Variables
    public BallStateMachine StateMachine { get; private set; }

    public BallAttachedToPlayerState AttachedToPlayerState { get; private set; }
    public BallMoveState MoveState { get; private set; }

    [SerializeField]
    private BallData ballData;
    #endregion

    #region Components
    [SerializeField]
    public GameObject PlayerGameobject;

    public PlayerInputHandler InputHanlder { get; private set; }
    public Rigidbody2D RB { get; private set; }

    public GameObject deadZone;
    #endregion

    #region Other Variables
    private Vector2 workspace;
    public Vector2 CurrentVelocity { get; private set; }
    #endregion

    #region Unity Callback Functions
    private void Awake() {
        StateMachine = new BallStateMachine();

        AttachedToPlayerState = new BallAttachedToPlayerState(this, StateMachine, ballData);
        MoveState = new BallMoveState(this, StateMachine, ballData);
    }

    private void Start() {
        InputHanlder = PlayerGameobject.GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();

        StateMachine.Initialize(AttachedToPlayerState);
    }

    private void Update() {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate() {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Other Functions
    public void SetVelocityZero() {
        RB.velocity = Vector2.zero;
        CurrentVelocity = Vector2.zero;
    }

    public void Eject() {
        workspace = new Vector3(Random.Range(-1.0F, 1.0F), 0, Mathf.Abs(Random.value));

        workspace = workspace.normalized * ballData.minimumSpeed;

        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void Moving () {
        //Get current speed and direction
        Vector3 direction = RB.velocity;
        float speed = direction.magnitude;
        direction.Normalize();

        //Make sure the ball never goes straight horizotal else it could never come down to the paddle.
        if (direction.y > -ballData.minimumVerticalMovement && direction.y < ballData.minimumVerticalMovement) {
            //Adjust the y, make sure it keeps going into the direction it was going (up or down)
            direction.y = direction.y < 0 ? -ballData.minimumVerticalMovement : ballData.minimumVerticalMovement;

            //Adjust the x also as x + y = 1
            direction.x = direction.x < 0 ? -1 + ballData.minimumVerticalMovement : 1 - ballData.minimumVerticalMovement;

            //Apply it back to the ball
            RB.velocity = direction * speed;
        }

        //Make sure the ball never goes straight horizotal else it could never come down to the paddle.
        if (direction.x > -ballData.minimumVerticalMovement && direction.x < ballData.minimumVerticalMovement) {
            //Adjust the y, make sure it keeps going into the direction it was going (up or down)
            direction.x = direction.x < 0 ? -ballData.minimumVerticalMovement : ballData.minimumVerticalMovement;

            //Adjust the x also as x + y = 1
            direction.y = direction.y < 0 ? -1 + ballData.minimumVerticalMovement : 1 - ballData.minimumVerticalMovement;

            //Apply it back to the ball
            RB.velocity = direction * speed;
        }

        if (speed < ballData.minimumSpeed || speed > ballData.maximumSpeed) {
            //Limit the speed so it always above min en below max
            speed = Mathf.Clamp(speed, ballData.minimumSpeed, ballData.maximumSpeed);

            //Apply the limit
            //Note that we don't use * Time.deltaTime here since we set the velocity once, not every frame.
            RB.velocity = direction * speed;
        }
    }
    #endregion
}
