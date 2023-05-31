using System;
using UniRx;
using UnityEngine;

public class WallsInterectable : Interactable
{
    public Vector3 VirtualNormal = Vector3.zero;

    public override event Action<PerformedInteractionContext> OnInteract;
    public static event Action<WallsInterectable> OnWallInteract;

    private ActiveInteraction _currentInteraction = ActiveInteraction.Off;
    
    public override void Interact(CallInteractionContext ctx)
    {
        //if (!ctx.started) return;
        Debug.Log("Wall Interact");

        OnInteract?.Invoke(new PerformedInteractionContext
        {
            Interactable = this,
            ActiveInteraction = ActiveInteraction.Idle
        });

        OnWallInteract?.Invoke(this);
    }
}
