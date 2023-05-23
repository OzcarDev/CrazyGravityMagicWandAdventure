using System;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(GravityEntity))]
public class CubeInteractable : Interactable
{
    private static Subject<CubeInteractable> _onCubeSelected = new();
    public static IObservable<CubeInteractable> OnCubeSelected => _onCubeSelected;

    public GravityEntity GravEntity => _gravEntity;
    private GravityEntity _gravEntity;

    private void Awake()
    {
        _gravEntity = GetComponent<GravityEntity>();
    }

    public override void Interact(InteractionContext ctx)
    {
        //if (!ctx.started) return;
        Debug.Log("Cube Interact");

        _onCubeSelected.OnNext(this);
    }
}
