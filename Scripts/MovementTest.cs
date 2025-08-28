using UnityEngine;
using UnityEngine.InputSystem;

public class MovementTest : MonoBehaviour
{
    public Rigidbody rb;
    public InputActionAsset inputSystem;
    public InputAction moveInput;
    public string moveInputName ="Move";
    public Vector2 moveDir;
    public float moveSpeed;
    public float deadzone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    void Awake()
    {
        FindInputActions();
    }

    void FindInputActions()
    {
        // Find and assign input actions
        moveInput = inputSystem.FindAction(moveInputName);

        if (moveInput == null)
        {
            Debug.LogError("One or more input actions not found. Please check the Input Action Asset.");
        }
        else{
            Debug.Log("All Good");
        }
    }

    public void OnMove(InputAction.CallbackContext value)
    {
        moveDir = value.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        // moveDir = moveInput.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if (moveDir.magnitude < deadzone) return;
        var motion = (Vector3.right * moveDir.x + Vector3.forward * moveDir.y) * moveSpeed;
        rb.linearVelocity = motion * Time.deltaTime;
    }
}
