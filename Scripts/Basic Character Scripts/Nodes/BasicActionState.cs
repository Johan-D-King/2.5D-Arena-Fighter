using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public abstract class BasicActionState : Action
{
    protected CharacterMain main;
    protected abstract PlayerState TargetState { get; }

    public override void OnStart()
    {
        main = this.GetComponent<CharacterMain>();
    }

    // Call this in OnUpdate of derived classes
    protected TaskStatus CheckState()
    {
        if (main.GetPlayerState() != TargetState)
        {
            return TaskStatus.Failure;
        }
        return TaskStatus.Running;
    }
}
