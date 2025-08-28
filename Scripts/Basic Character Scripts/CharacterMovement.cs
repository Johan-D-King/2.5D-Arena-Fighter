using BehaviorDesigner.Runtime.ObjectDrawers;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterMain main;
    public const float baseSpeed = 200f;

    public float moveSpeed;
    public float fMoveSpeed = 1f;
    public float bMoveSpeed = 0.5f;
    public float vMoveSpeed = 0.7f;

    public Vector2 dashDir;
    public float dashSpeed;
    public float fDashSpeed = 2f;
    public float bDashSpeed = 1.5f;
    public float vDashSpeed = 1.7f;

    public float dashDuration = 0.5f;
    private float dashTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMoveSpeed(Vector2 dir)
    {
        // Move the character based on the input direction and speed
        float speed = fMoveSpeed;
        if (dir.x != main.facingDir) speed = bMoveSpeed;
        if (dir.x == 0) speed = vMoveSpeed;

        moveSpeed = speed;
    }

    public void SetDashSpeed(Vector2 dir)
    {
        // Move the character based on the input direction and speed
        float newSpeed = fDashSpeed;
        if (dir.x != main.facingDir) newSpeed = bDashSpeed;
        if (dir.x == 0) newSpeed = vDashSpeed;

        dashDir = dir;
        dashSpeed = newSpeed;
    }

    public bool IsDashing()
    {
        if (dashTime >= dashDuration)
        {
            dashTime = 0;
            return false;
        }
        dashTime += Time.deltaTime;
        return true;
    }

    public void MoveCharacter(Vector2 direction, float speed)
    {
        main.rb.linearVelocity = new Vector3(direction.x, 0, direction.y) * baseSpeed * speed * Time.deltaTime;
    }
}
