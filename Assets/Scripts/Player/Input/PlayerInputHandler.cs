using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;
    private Camera cam;

    public Vector2 RawMovementInput { get; private set; }
    public int NormalizeInputX { get; private set; }
    public int NormalizeInputY { get; private set; }
    public bool EjectInput { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.2f;

    private float jumpInputStartTime;
    private float dashInputStartTime;

    private void Start() {
        playerInput = GetComponent<PlayerInput>();
        cam = Camera.main;
    }

    private void Update() {
        
    }

    public void OnMoveInput(InputAction.CallbackContext context) {
        RawMovementInput = context.ReadValue<Vector2>();

        if(Mathf.Abs(RawMovementInput.x) > 0.5f) {
            NormalizeInputX = (int)(RawMovementInput * Vector2.right).normalized.x;
        } else {
            NormalizeInputX = 0;
        }
        
        if(Mathf.Abs(RawMovementInput.y) > 0.5f) {
            NormalizeInputY = (int)(RawMovementInput * Vector2.up).normalized.y;
        } else {
            NormalizeInputY = 0;
        }
    }

    public void OnEjectInput(InputAction.CallbackContext context) {
        if (context.started) {
            EjectInput = true;
        }

        if (context.canceled) {
            EjectInput = false;
        }
    }
}
