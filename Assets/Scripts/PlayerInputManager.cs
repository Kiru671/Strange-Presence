using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public InputActions inputActions;
    private MovementStateMachine stateMachine;
    [SerializeField] private GameManager gameManager;

    [SerializeField, Range(4f,15f)]

    public Vector2 rotation;
    public Vector2 move;

    public bool gamepadMoving;
    private void Awake()
    {
        inputActions = new InputActions();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Move.Walk.performed += cntxt => { move = cntxt.ReadValue<Vector2>();
            if (cntxt.control.device is Gamepad) { gamepadMoving = true; }
            else { gamepadMoving = false; }
        };
        inputActions.Move.LookShoot.performed += cntxt => rotation = cntxt.ReadValue<Vector2>();
        inputActions.Move.LookShoot.canceled += cntxt => rotation = Vector2.zero;
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
    
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (gameManager.gameStopped)
            {
                gameManager.ResumeGame();
            }
            else
            {
                gameManager.StopGame();
            }           
        }
    }
}
