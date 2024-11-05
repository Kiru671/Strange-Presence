using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private InputActions inputActions;
    private MovementStateMachine stateMachine;

    [SerializeField, Range(4f,15f)]
    private float moveSpeed = 4f;
    private Vector2 pos;

    private void Awake()
    {
        inputActions = new InputActions();
        stateMachine = new MovementStateMachine();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Move.Jump.performed += OnJump;
        inputActions.Move.Walk.performed += OnMove;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Move.Jump.performed -= OnJump;
        inputActions.Move.Walk.performed -= OnMove;
    }

    private void Update()
    {
        MovePlayer();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("SKIDIBOPMMDADA!!");
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveDirection = context.ReadValue<Vector2>();
    }

    private void MovePlayer()
    {
        Vector2 dir = inputActions.Move.Walk.ReadValue<Vector2>();
        pos = dir.normalized * moveSpeed * Time.deltaTime;
        Vector3 move = new Vector3(pos.x, 0, pos.y);
        transform.position += move;
    }
}
