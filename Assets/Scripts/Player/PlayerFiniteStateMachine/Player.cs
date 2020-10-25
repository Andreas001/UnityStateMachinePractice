using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    #region State Variables
    public PlayerStateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerDieState DieState { get; private set; }

    [SerializeField]
    private PlayerData playerData;
    #endregion

    #region Components
    public PlayerInputHandler InputHanlder { get; private set; }
    public Rigidbody2D RB { get; private set; }

    public GameObject SceneLoader;
    #endregion

    #region Other Variables
    private Vector2 workspace;
    public Vector2 CurrentVelocity { get; private set; }

    protected int playerHealth;
    [SerializeField]
    private List<GameObject> blocks;
    #endregion

    #region Unity Callback Functions
    private void Awake() {
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData);
        MoveState = new PlayerMoveState(this, StateMachine, playerData);
        DieState = new PlayerDieState(this, StateMachine, playerData);
    }

    private void Start() {
        InputHanlder = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        playerHealth = playerData.health;

        StateMachine.Initialize(IdleState);
    }

    private void Update() {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.LogicUpdate();

        if(playerHealth <= 0) {
            SceneLoader.GetComponent<SceneLoader>().LoadGameOverScene();
        }
    }

    private void FixedUpdate() {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Check Functions
    private void CheckBlocks() {
        bool allActive = true;

        for (int i = 0; i < blocks.Count; i++) {
            if (!blocks[i].activeInHierarchy) {
                allActive = false;
                break;
            }
        }

        if(!allActive) {
            SceneLoader.GetComponent<SceneLoader>().LoadWinScene();
        }
    }
    #endregion

    #region Set Functions
    public void SetVelocityX(float velocity) {
        workspace.Set(velocity, CurrentVelocity.y);
        RB.velocity = workspace;
        CurrentVelocity = workspace;
    }

    public void SetHealth(int health) {
        this.playerHealth = health;
    }

    public int GetHealth() {
        return this.playerHealth;
    }
    #endregion
}
