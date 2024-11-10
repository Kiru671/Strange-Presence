using UnityEngine.InputSystem;

public interface IMovementState
{
    void EnterState(MovementStateMachine context, PlayerInputManager inputs);
    void UpdateState(MovementStateMachine context, PlayerInputManager inputs);
    void PhysicsUpdateState(MovementStateMachine context, PlayerInputManager inputs);
    void ExitState(MovementStateMachine context, PlayerInputManager inputs);
    void Jump(InputAction.CallbackContext context);
    void Dash(InputAction.CallbackContext context);

    void LookAndShoot(InputAction.CallbackContext context);
}