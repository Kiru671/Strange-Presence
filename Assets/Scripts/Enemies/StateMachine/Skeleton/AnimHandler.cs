using System;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.StateMachine
{
    public class AnimHandler : MonoBehaviour
    {
        [SerializeField]
        private Animator anim;
        private NavMeshAgent agent;
        private Enemy enemy;

        void OnEnable()
        {
            agent = gameObject.GetComponent<NavMeshAgent>();
            enemy = gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.OnEnemyDeath += TriggerDeathAnim;
                enemy.OnEnemyHit += TriggerHitAnim;
            }
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
