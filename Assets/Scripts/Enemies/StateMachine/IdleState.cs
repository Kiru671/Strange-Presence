using UnityEngine.AI;

namespace Enemies.StateMachine
{
    public class IdleEnemyState: IEnemyState
    {
        private EnemyStateMachine stateMachine;
        private Player player;
        private NavMeshAgent agent;
        public void EnterState(EnemyStateMachine context, Enemy enemy)
        {
            stateMachine = context;
            player = stateMachine.player;
            agent = stateMachine.GetComponent<NavMeshAgent>();
        }

        public void UpdateState()
        {
            if(player.transform.position.y < stateMachine.transform.position.y + 1)
            {
                stateMachine.SwitchState(stateMachine.chaseState);
            }
        }

        public void PhysicsUpdateState()
        {
            
        }

        public void ExitState()
        {

        }

        public void Move()
        {

        }
    }
}

