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
        public Enemy enemy;
        
        [SerializeField, Range(2f,10f)]
        public float lerpAmount = 5f;
        [SerializeField, Range(0f,10f)]
        public float attackRecoveryTime = 1f;
        [SerializeField, Range(1f,20f)]
        public float attackRange = 3f;
        
        public bool TargetInRange => Vector3.Distance(transform.position, player.transform.position) < attackRange;

 
        void Start()
        {
            player = GameObject.FindObjectOfType<Player>();
            enemy = gameObject.GetComponent<Enemy>();
            
            // Initialize states.
            idleState = new IdleEnemyState();
            chaseState = new ChaseState();
            attackState = new AttackState();

            // Set initial state
            currentState = idleState;  
            currentState.EnterState(this, enemy);
        }
    
        private void Update()
        {
            currentState.UpdateState();
        }

        public void SwitchState(IEnemyState newState)
        {
            currentState.ExitState();
            currentState = newState;
            currentState.EnterState(this, enemy);
        }
    }
}