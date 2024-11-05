using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementStateMachine
{
    private PlayerInputManager inputManager;
    private IMovementState currentState;

    // State instances
    private GroundMoveState groundState;
    private DashMovementState dashState;

 
    void Start()
    {
        Debug.Log("Instantiated state machine");
        // Initialize states with reference to the Move script
        groundState = new GroundMoveState();
        dashState = new DashMovementState();

        // Set initial state
        currentState = groundState;
        currentState.EnterState(this);
    }
   

    void UpdateState()
    { 

    }

    private void SwitchState(IMovementState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}