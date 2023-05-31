using System;
using UniRx;
using UnityEngine;

[RequireComponent(typeof(GravityEntity))]
public class CubeInteractable : Interactable
{
    public override event Action<PerformedInteractionContext> OnInteract;
    public static event Action<CubeInteractable> OnCubeInteract;

    public GravityEntity GravEntity => _gravEntity;
    private GravityEntity _gravEntity;


    private bool _isMoving => _gravEntity.Rb.velocity != Vector3.zero;

    private void Awake()
    {
        _gravEntity = GetComponent<GravityEntity>();
    }

    public override void Interact(CallInteractionContext ctx)
    {
        //if (_isMoving) return;
        //if (!ctx.started) return;

        Debug.Log("Cube Interact");

        OnInteract?.Invoke(new PerformedInteractionContext { 
            Interactable = this
        });

        OnCubeInteract?.Invoke(this);
    }
}
