using UnityEngine;
using UnityEngine.AI;
using System;
using Unity.VisualScripting;

namespace Enemies.StateMachine
{
    public class AttackState : IEnemyState
    {
        private EnemyStateMachine stateMachine;
        private Player player;
        private Enemy enemy;
        private NavMeshAgent agent;
        private Animator anim;
        private bool isAttacking = false;
        
        public void EnterState(EnemyStateMachine context, Enemy enemy)
        {
            stateMachine = context;
            player = stateMachine.player;
            this.enemy = enemy;
            anim = stateMachine.GetComponentInChildren<Animator>();
            agent = enemy.agent;
            
            Debug.Log("Entered Attack State");
            enemy.OnEnemyCooldownOver += TriggerAttackAnim;
        }
        
        public void ExitState()
        {
            // Resume movement
            if (agent != null)
            {
                agent.isStopped = false;
            }
            
            enemy.OnEnemyCooldownOver -= TriggerAttackAnim;
        }

        public void UpdateState()
        {
            TriggerAttackAnim();

            // Look at target while attacking
            if (player != null)
            {
                Vector3 direction = (player.transform.position - enemy.transform.position).normalized;
                Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
                enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation, lookRotation, Time.deltaTime * 5f);
            }
            
            if (!enemy.TargetInRange)
            {
                Debug.Log("Switching to Chase State - Target out of range");
                stateMachine.SwitchState(stateMachine.chaseState);
            }
        }

        public void PhysicsUpdateState()
        {
            // Handle physics-based updates if needed
        }
        
        private void TriggerAttackAnim()
        {
            enemy.Attack();
        }
    }
}

