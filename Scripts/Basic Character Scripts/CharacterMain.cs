using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{
    Idle,
    Walking,
    Dashing
}

public class CharacterMain : MonoBehaviour
{
    public PlayerState playerState;
    public PlayerState nextPlayerState;

    public CharacterMovement movementController;
    public Rigidbody rb;
    public InputActionAsset inputSystem;

    public InputAction moveInput;
    public string moveInputName = "Move";

    public InputAction dashInput;
    public string dashInputName = "Dash";

    public int facingDir;
    public Vector2 moveDir;
    public float moveDeadzone = 0.5f;
    public bool dashInputted;
    public bool allowLook;
    public Transform lookAtTarget;

    void Awake()
    {
        FindInputActions();
    }

    void FindInputActions()
    {
        // Find and assign input actions
        moveInput = inputSystem.FindAction(moveInputName);
        dashInput = inputSystem.FindAction(dashInputName);

        if (moveInput == null || dashInput == null)
        {
            Debug.LogError("One or more input actions not found. Please check the Input Action Asset.");
        }
        else
        {
            Debug.Log("All Good");
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LookAtTarget()
    {
        if (lookAtTarget != null && allowLook)
        {
            if (lookAtTarget.position.x < transform.position.x)
            {
                facingDir = -1;
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                facingDir = 1;
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        moveDir = value.ReadValue<Vector2>();
    }

    public Vector2 GetMoveDir()
    {
        return moveDir;
    }

    public void DashInputted(InputAction.CallbackContext value)
    {
        dashInputted = (value.action.WasPressedThisFrame()) ? true : false;
    }

    public void SetPlayerState(PlayerState newState)
    {
        if (playerState == newState) return;

        playerState = newState;
    }

    public void SetNextPlayerState(PlayerState newState)
    {
        if (nextPlayerState == newState) return;

        nextPlayerState = newState;
    }

    public PlayerState GetPlayerState()
    {
        return playerState;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}
