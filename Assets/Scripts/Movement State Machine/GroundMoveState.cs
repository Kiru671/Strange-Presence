using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class GroundMoveState : IMovementState
{
    private GameObject player;
    private Vector2 rotation;
    private MovementStateMachine stateMachine;
    private PlayerInputManager inputManager;
    public void EnterState(MovementStateMachine context, PlayerInputManager inputs)
    {
        Debug.Log("GroundState");
        stateMachine = context;
        player = context.gameObject;
        inputManager = inputs;
        //Set private rotation to returned rotation vector from input manager.
        
        inputs.inputActions.Move.Jump.performed -= inputs.OnJump;

        inputs.inputActions.Move.Jump.performed += Jump;
    }

    public void ExitState()
    {
        
    }

    public void PhysicsUpdateState()
    {
        
    }

    public void UpdateState()
    {
        LookAndShoot();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log("GroundJump");
    }

    public void Dash(InputAction.CallbackContext context)
    {

    }
    public void LookAndShoot()
    {
        rotation = inputManager.rotation;
        if (rotation.magnitude > 0)
        {           
            Vector3 direction = new Vector3(rotation.x, 0, rotation.y);
            Quaternion tragetRotation = Quaternion.LookRotation(direction);
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, tragetRotation, stateMachine.lerpAmount);
        }
    }
}
