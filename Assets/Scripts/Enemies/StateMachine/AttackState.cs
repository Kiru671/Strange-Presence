using UnityEngine;
using UnityEngine.AI;
using System;

namespace Enemies.StateMachine
{
    public class AttackState : IEnemyState
    {
        private EnemyStateMachine stateMachine;
        private Player player;
        private Enemy enemy;
        private NavMeshAgent agent;
        private Animator anim;
        
        public void EnterState(EnemyStateMachine context, Enemy enemy)
        {
            stateMachine = context;
            player = stateMachine.player;
            this.enemy = enemy;
            anim = stateMachine.GetComponent<Animator>();
            Debug.Log("Entered Attack State");
            enemy.OnEnemyCooldownOver += TriggerAttackAnim;
            
        }
        
        public void ExitState()
        {
            enemy.OnEnemyCooldownOver -= TriggerAttackAnim;
        }

        public void UpdateState()
        {
            if(enemy.AttackCooldown)
            {
                enemy.OnCooldownOver();
            }
            if (!enemy.TargetInRange)
            {
                stateMachine.SwitchState(stateMachine.chaseState);
            }
        }

        public void PhysicsUpdateState()
        {

        }
        
        private void TriggerAttackAnim()
        {
            anim.SetTrigger("Attack");
            Debug.Log("AttackingAnimation"); 
        }
    }
    
}
