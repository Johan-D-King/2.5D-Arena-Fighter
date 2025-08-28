using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class IdleState : BasicActionState
{
    protected override PlayerState TargetState => PlayerState.Idle;

    public override TaskStatus OnUpdate()
    {
        var stateCheck = CheckState();
        if (stateCheck != TaskStatus.Running)
            return stateCheck;

        HandleInputs();
        return TaskStatus.Running;
    }

    private void HandleInputs()
    {
        main.LookAtTarget();

        if (main.GetMoveDir() != Vector2.zero && main.GetMoveDir().magnitude > main.moveDeadzone)
        {
            main.SetPlayerState(PlayerState.Walking);
            main.movementController.SetMoveSpeed(main.GetMoveDir());
            return;
        }
        
    }
}
