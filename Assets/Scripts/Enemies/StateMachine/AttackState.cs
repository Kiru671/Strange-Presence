using UnityEngine;
using UnityEngine.AI;

namespace Enemies.StateMachine
{
    public class AttackState : IEnemyState
    {
        private EnemyStateMachine stateMachine;
        private Player player;
        private NavMeshAgent agent;
        private Animator anim;
        
        public void EnterState(EnemyStateMachine context)
        {
            stateMachine = context;
            player = stateMachine.player;
            agent = stateMachine.GetComponent<NavMeshAgent>();
            anim = stateMachine.GetComponent<Animator>();
        }

        public void UpdateState()
        {
    
        }

        public void PhysicsUpdateState()
        {

        }

        public void ExitState()
        {

        }
    }
}
