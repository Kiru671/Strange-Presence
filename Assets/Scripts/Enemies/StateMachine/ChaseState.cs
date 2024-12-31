using UnityEngine;
using UnityEngine.AI;

namespace Enemies.StateMachine
{
    public class ChaseState : IEnemyState
    {
        private EnemyStateMachine stateMachine;
        private Player player;
        private Enemy enemy;
        public void EnterState(EnemyStateMachine context, Enemy enemy)
        {
            stateMachine = context;
            player = stateMachine.player;
            this.enemy = enemy;
            Debug.Log("Entered Chase State");
        }

        public void UpdateState()
        {
            enemy.agent.SetDestination(player.transform.position);
            if(enemy.TargetInRange)
            {
                stateMachine.SwitchState(stateMachine.attackState);
            }
        }

        public void PhysicsUpdateState()
        {

        }

        public void ExitState()
        {

        }
    }
}
