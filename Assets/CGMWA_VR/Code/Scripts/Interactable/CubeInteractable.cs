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
    
    private Vector3 _lastDir = Vector3.down;

    private void Awake()
    {
        _gravEntity = GetComponent<GravityEntity>();
    }

    public override void Interact(CallInteractionContext ctx)
    {
        if (_isMoving) return;

        Debug.Log("Cube Interact");

        OnInteract?.Invoke(new PerformedInteractionContext { 
            Interactable = this
        });

        OnCubeInteract?.Invoke(this);
    }

    private bool _isMoving = false;

    private void OnGravityChange(Vector3 newDir)
    {
        if (newDir == _lastDir) return;

        _lastDir = newDir;
        
        Debug.Log("Cambio de gravedad");
        _isMoving = true;
    }

    private void OnEnable()
    {
        _gravEntity.OnGravityChange += OnGravityChange;
    }

    private void OnDisable()
    {
        _gravEntity.OnGravityChange -= OnGravityChange;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Wall")) return;

        if (_isMoving)
        {
            _isMoving = false;
            Debug.Log("Se puede mover");
        }
    }
}
