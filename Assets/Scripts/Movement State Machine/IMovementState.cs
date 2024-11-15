using UnityEngine.InputSystem;

public interface IMovementState
{
    void EnterState(MovementStateMachine context, PlayerInputManager inputs);
    void UpdateState();
    void PhysicsUpdateState();
    void ExitState();
    void Move();
    void Dash(InputAction.CallbackContext context);
    void LookAndShoot();
    
}