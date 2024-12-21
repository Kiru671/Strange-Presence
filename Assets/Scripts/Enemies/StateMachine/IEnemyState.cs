namespace Enemies.StateMachine
{
    public interface IEnemyState
    {
        void EnterState(EnemyStateMachine context);
        void UpdateState();
        void PhysicsUpdateState();
        void ExitState();
    }
}