using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public InputActions inputActions;
    private MovementStateMachine stateMachine;

    [SerializeField, Range(4f,15f)]
    private float moveSpeed = 4f;

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
        inputActions.Move.LookShoot.performed += OnLookAndShoot;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Move.Jump.performed -= OnJump;
        inputActions.Move.Walk.performed -= OnMove;
        inputActions.Move.LookShoot.performed -= OnLookAndShoot;
    }

    private void Update()
    {
        MovePlayer();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("SKIDIBOPMMDADA!!");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveDirection = context.ReadValue<Vector2>();
        Debug.Log("Moving");
    }

    public void MovePlayer()
    {
        Vector2 dir = inputActions.Move.Walk.ReadValue<Vector2>();
        Vector2 pos = dir.normalized * moveSpeed * Time.deltaTime;
        Vector3 move = new Vector3(pos.x, 0, pos.y);
        transform.position += move;
    }

    public void OnLookAndShoot(InputAction.CallbackContext context)
    {

    }
}
