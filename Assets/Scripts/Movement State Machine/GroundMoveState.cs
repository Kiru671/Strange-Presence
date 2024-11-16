using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class GroundMoveState : IMovementState
{
    private GameObject player;
    private Player playerScript;
    private Vector2 rotation;
    private MovementStateMachine stateMachine;
    private PlayerInputManager inputManager;
    private Weapon chosenWeapon;
    public void EnterState(MovementStateMachine context, PlayerInputManager inputs)
    {
        Debug.Log("GroundState");
        stateMachine = context;
        player = context.gameObject;
        playerScript = player.gameObject.GetComponent<Player>();
        inputManager = inputs;
        inputs.inputActions.Move.Dash.performed -= inputs.OnDash;
        inputs.inputActions.Move.Dash.performed += Dash;
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
        Move();
    }

    public void Move()
    {
        Vector2 pos = inputManager.move.normalized * playerScript.moveSpeed * Time.deltaTime;
        Vector3 move = new Vector3(pos.x, 0, pos.y);
        player.transform.position += move;
    }

    public void Dash(InputAction.CallbackContext context)
    {
        Debug.Log("GroundDash");
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
