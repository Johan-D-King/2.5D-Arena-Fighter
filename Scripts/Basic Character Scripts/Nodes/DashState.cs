using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class DashState : BasicActionState
{
    protected override PlayerState TargetState => PlayerState.Walking;

    public override TaskStatus OnUpdate()
    {
        var stateCheck = CheckState();
        if (stateCheck != TaskStatus.Running)
            return stateCheck;

        if (!main.movementController.IsDashing())
        {
            HandleInputs();
        }

        return TaskStatus.Running;
    }

    public override void OnFixedUpdate()
    {
        main.movementController.MoveCharacter(main.movementController.dashDir, main.movementController.dashSpeed);
    }

    private void HandleInputs()
    {
        main.LookAtTarget();

        if(main.GetMoveDir() != Vector2.zero && main.GetMoveDir().magnitude > main.moveDeadzone)
        {
            main.SetPlayerState(PlayerState.Walking);
            main.movementController.SetMoveSpeed(main.GetMoveDir());
            return;
        }

        if (main.GetMoveDir() == Vector2.zero || main.GetMoveDir().magnitude < main.moveDeadzone)
        {
            main.SetPlayerState(PlayerState.Idle);
            return;
        }
    }

}
