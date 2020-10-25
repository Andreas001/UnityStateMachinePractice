using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public string startingColor = "Red";

    #region State Variables
    public BlockStateMachine StateMachine { get; private set; }

    public BlockRedState RedState { get; private set; }
    public BlockYellowState YellowState { get; private set; }
    public BlockGreenState GreenState { get; private set; }
    public BlockDeadState DeadState { get; private set; }

    [SerializeField]
    private BlockData blockData;
    #endregion

    #region Components
    public Collider2D col;

    public SpriteRenderer sr;
    #endregion

    public bool gotHit = false;

    #region Unity Callback Functions
    private void Awake() {
        StateMachine = new BlockStateMachine();

        RedState = new BlockRedState(this, StateMachine, blockData);
        YellowState = new BlockYellowState(this, StateMachine, blockData);
        GreenState = new BlockGreenState(this, StateMachine, blockData);
        DeadState = new BlockDeadState(this, StateMachine, blockData);
    }

    private void Start() {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();

        switch(startingColor) {
            case "Red": StateMachine.Initialize(RedState);
                break;
            case "Yellow": StateMachine.Initialize(YellowState);
                break;
            case "Green": StateMachine.Initialize(GreenState);
                break;
        }
    }

    private void Update() {
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate() {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Ball") {
            gotHit = true;
        }
    }
}
