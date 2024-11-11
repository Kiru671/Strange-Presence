using UnityEngine.InputSystem;

public interface IMovementState
{
    void EnterState(MovementStateMachine context, PlayerInputManager inputs);
    void UpdateState();
    void PhysicsUpdateState();
    void ExitState();
    void Jump(InputAction.CallbackContext context);
    void Dash(InputAction.CallbackContext context);

    void LookAndShoot();
}