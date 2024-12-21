namespace Enemies.StateMachine
{
    public interface IEnemyState
    {
        void EnterState(EnemyStateMachine context, Enemy enemy);
        void UpdateState();
        void PhysicsUpdateState();
        void ExitState();
    }
}