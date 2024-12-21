using UnityEngine.InputSystem;

namespace Movement_State_Machine
{
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
}