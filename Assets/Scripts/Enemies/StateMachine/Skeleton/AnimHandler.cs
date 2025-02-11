using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.StateMachine
{
    public class AnimHandler : MonoBehaviour
    {
        private Animator anim;
        private NavMeshAgent agent;
        private Enemy enemy;

        void OnEnable()
        {
            anim = gameObject.GetComponent<Animator>();
            agent = gameObject.GetComponent<NavMeshAgent>();
            enemy = gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.OnEnemyCooldownOver += TriggerAttackAnim;
                enemy.OnEnemyDeath += TriggerDeathAnim;
                enemy.OnEnemyHit += TriggerHitAnim;
            }
        }

        public void TriggerAttackAnim()
        {
            anim.SetTrigger("Attack");
        }
        
        public void TriggerDeathAnim()
        {
            anim.SetTrigger("Death");
        }
        
        public void TriggerHitAnim()
        {
            anim.SetTrigger("Hit");
        }

        void Update()
        {
            anim.SetFloat("Speed", agent.velocity.magnitude);
        }

    }
    
}
