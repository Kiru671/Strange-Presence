public interface IMovementState
{
    void EnterState(MovementStateMachine context);
    void UpdateState(MovementStateMachine context, PlayerInputManager inputs);
    void PhysicsUpdateState(MovementStateMachine context, PlayerInputManager inputs);
    void ExitState(MovementStateMachine context);
    void Jump();
    void Dash();
}