using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public InputActions inputActions;
    private MovementStateMachine stateMachine;

    [SerializeField, Range(4f,15f)]
    public float moveSpeed = 4f;

    public Vector2 rotation;
    public Vector2 move;

    private void Awake()
    {
        inputActions = new InputActions();
        stateMachine = new MovementStateMachine();
    }
    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Move.Dash.performed += OnDash;
        inputActions.Move.Walk.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputActions.Move.LookShoot.performed += cntxt => rotation = cntxt.ReadValue<Vector2>();
        inputActions.Move.LookShoot.canceled += cntxt => rotation = Vector2.zero;
        //inputActions.Move.LookShoot.performed += OnLookAndShoot;
    }

    private void OnDisable()
    {
        inputActions.Disable();
        inputActions.Move.Dash.performed -= OnDash;

    }

    public void OnDash(InputAction.CallbackContext context)
    {
        Debug.Log("SKIDIBOPMMDADA!!");
    }


    public void MovePlayer()
    {

    }

    public void OnLookAndShoot(InputAction.CallbackContext context)
    {

    }
}
