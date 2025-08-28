using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class MoveState : BasicActionState
{
    protected override PlayerState TargetState => PlayerState.Walking;

    public override TaskStatus OnUpdate()
    {
        var stateCheck = CheckState();
        if (stateCheck != TaskStatus.Running)
            return stateCheck;

        HandleInputs();
        return TaskStatus.Running;
    }

    public override void OnFixedUpdate()
    {
        main.movementController.MoveCharacter(main.GetMoveDir(), main.movementController.moveSpeed);
    }

    private void HandleInputs()
    {
        main.LookAtTarget();
        main.movementController.SetMoveSpeed(main.GetMoveDir());

        if(main.dashInputted)
        {
            main.SetPlayerState(PlayerState.Dashing);
            main.movementController.SetDashSpeed(main.GetMoveDir());
            return;
        }

        if (main.GetMoveDir() == Vector2.zero || main.GetMoveDir().magnitude < main.moveDeadzone)
        {
            main.SetPlayerState(PlayerState.Idle);
            return;
        }
    }
}
