using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMoveState : IMovementState
{
    public void EnterState(MovementStateMachine context)
    {
        Debug.Log("GroundState");
    }

    public void ExitState(MovementStateMachine context)
    {
        
    }

    public void PhysicsUpdateState(MovementStateMachine context, PlayerInputManager inputs)
    {
        
    }

    public void UpdateState(MovementStateMachine context, PlayerInputManager inputs)
    {
        
    }

    public void Jump()
    {

    }

    public void Dash()
    {

    }
}
