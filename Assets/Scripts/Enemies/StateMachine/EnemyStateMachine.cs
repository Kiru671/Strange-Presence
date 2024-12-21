using Movement_State_Machine;
using UnityEngine;

namespace Enemies.StateMachine
{
    public class EnemyStateMachine: MonoBehaviour
    {
        private PlayerInputManager inputManager;
        private IEnemyState currentState;

        // State instances
        public IdleEnemyState idleState;
        public ChaseState chaseState;
        public AttackState attackState;

        public Player player;
        
        [SerializeField, Range(2f,10f)]
        public float lerpAmount = 5f;
        [SerializeField, Range(0f,10f)]
        public float attackRecoveryTime = 1f;

 
        void Start()
        {
            player = GameObject.FindObjectOfType<Player>();
            
            // Initialize states.
            idleState = new IdleEnemyState();
            chaseState = new ChaseState();
            attackState = new AttackState();

            // Set initial state
            currentState = idleState;  
            currentState.EnterState(this);
        }
    
        private void Update()
        {
            currentState.UpdateState();
        }

        public void SwitchState(IEnemyState newState)
        {
            currentState.ExitState();
            currentState = newState;
            currentState.EnterState(this);
        }
    }
}