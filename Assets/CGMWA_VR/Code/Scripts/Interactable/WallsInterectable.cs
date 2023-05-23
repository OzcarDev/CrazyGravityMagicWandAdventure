using System;
using UniRx;
using UnityEngine;

public class WallsInterectable : Interactable
{
    private static Subject<WallsInterectable> _onWallSelected = new();
    public static IObservable<WallsInterectable> OnWallSelected => _onWallSelected;
    
    public override void Interact(InteractionContext ctx)
    {
        //if (!ctx.started) return;
        Debug.Log("Wall Interact");
        _onWallSelected.OnNext(this);
    }
}
