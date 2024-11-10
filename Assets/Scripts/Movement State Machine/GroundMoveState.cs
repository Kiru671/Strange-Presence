using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GroundMoveState : IMovementState
{
    private GameObject player;
    public void EnterState(MovementStateMachine context, PlayerInputManager inputs)
    {
        Debug.Log("GroundState");
        player = context.gameObject;
        inputs.inputActions.Move.Jump.performed -= inputs.OnJump;

        inputs.inputActions.Move.Jump.performed += Jump;
        inputs.inputActions.Move.LookShoot.performed += LookAndShoot;
    }

    public void ExitState(MovementStateMachine context, PlayerInputManager inputs)
    {
        
    }

    public void PhysicsUpdateState(MovementStateMachine context, PlayerInputManager inputs)
    {
        
    }

    public void UpdateState(MovementStateMachine context, PlayerInputManager inputs)
    {
        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("GroundJump");
    }

    public void Dash(InputAction.CallbackContext context)
    {

    }
    public void LookAndShoot(InputAction.CallbackContext context)
    {
        //player.transform.rotation = Quaternion.LookRotation(Vector3.forward, context.ReadValue<Vector3>());
    }
}
