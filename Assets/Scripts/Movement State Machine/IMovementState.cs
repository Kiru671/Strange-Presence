public interface IMovementState
{
    void EnterState(MovementStateMachine context);
    void UpdateState(MovementStateMachine context);
    void PhysicsUpdateState(MovementStateMachine context);
    void ExitState(MovementStateMachine context);
}