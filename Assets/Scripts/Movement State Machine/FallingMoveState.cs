using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement_State_Machine
{
    public class FallingMoveState : IMovementState
    {
        private GameObject player;
        private Player playerScript;
        private Vector2 rotation;
        private MovementStateMachine stateMachine;
        private PlayerInputManager inputManager;
        private Weapon chosenWeapon;
        private float rayLength;
        private bool isGamepadActiveShoot;
        public void EnterState(MovementStateMachine context, PlayerInputManager inputs)
        {
            Debug.Log("FallingState");
            stateMachine = context;
            player = context.gameObject;
            playerScript = player.gameObject.GetComponent<Player>();
            inputManager = inputs;
            inputs.inputActions.Move.Dash.performed += Dash;
        }

        public void UpdateState()
        {
            isGamepadActiveShoot = false;
            LookAndShoot();
            Ray camRay = Camera.main.ScreenPointToRay(UnityEngine.Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, new Vector3(0,player.transform.position.y,0));
        

            if (groundPlane.Raycast(camRay, out rayLength) &!isGamepadActiveShoot)
            {
                Vector3 pointToLook = camRay.GetPoint(rayLength);
                Debug.DrawLine(camRay.origin, pointToLook, Color.cyan);
                player.transform.LookAt(new Vector3(pointToLook.x, player.transform.position.y, pointToLook.z));
            }
            if(Physics.Raycast(player.transform.position, Vector3.down, out RaycastHit hit, 1.25f, LayerMask.GetMask("Ground")))
            {
                stateMachine.SwitchState(stateMachine.groundState);
            }

            Move();
            ApplyGravity();
        }

        public void PhysicsUpdateState()
        {
    
        }
        

        public void ExitState()
        {
            inputManager.inputActions.Move.Dash.performed -= Dash;
        }

        public void Move()
        {
            if (inputManager.move.magnitude > 0)
            {
                Vector2 pos = inputManager.move.normalized * playerScript.moveSpeed * Time.deltaTime;
                Vector3 move = new Vector3(pos.x, 0, pos.y);
                player.transform.position += move * 0.5f;
            }
        }

        public void Dash(InputAction.CallbackContext context)
        {
            Debug.Log("FallingDash");
        }
        
        public void LookAndShoot()
        {
            rotation = inputManager.rotation;
            if (rotation.magnitude > 0)
            {
                isGamepadActiveShoot = true;
                Vector3 direction = new Vector3(rotation.x, 0, rotation.y);
                Quaternion tragetRotation = Quaternion.LookRotation(direction);
                player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, tragetRotation, stateMachine.lerpAmount);
            }
        }

        public void ApplyGravity()
        {
            Vector3 gravityVector = Vector3.down *10* Time.deltaTime;
            player.transform.position += gravityVector;
        }
    }
}