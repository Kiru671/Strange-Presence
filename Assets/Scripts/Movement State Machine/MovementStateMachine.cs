using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateMachine: MonoBehaviour
{
    private PlayerInputManager inputManager;
    private IMovementState currentState;

    // State instances
    private GroundMoveState groundState;
    private DashMovementState dashState;
    [SerializeField, Range(2f,10f)]
    public float lerpAmount = 5f;

 
    void Start()
    {
        inputManager = GetComponent<PlayerInputManager>();
        Debug.Log("Instantiated state machine");

        // Initialize states.
        groundState = new GroundMoveState();
        dashState = new DashMovementState();

        // Set initial state
        currentState = groundState;  
        currentState.EnterState(this, inputManager);
    }
    private void Update()
    {
        currentState.UpdateState();
    }


    private void SwitchState(IMovementState newState)
    {
        currentState.ExitState();
        currentState = newState;
        currentState.EnterState(this, inputManager);
    }
}