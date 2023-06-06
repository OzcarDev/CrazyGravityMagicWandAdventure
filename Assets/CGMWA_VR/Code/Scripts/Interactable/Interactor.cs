using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private Interactable _currentInteractable;
    
    [SerializeField]
    private Transform _interactorOriginRay;

    [SerializeField] private LayerMask _interactLayer;

    [SerializeField] private TrailRenderer _trail;


    public void CheckRaycastInteraction()
    {
        if (!RayCast(out var hit)) return;

        if (!hit.transform.TryGetComponent<Interactable>(out var interactable)) return;
        
        if(!interactable) return;

        _currentInteractable = interactable;
        
        interactable.Interact(new CallInteractionContext()
        {
            Actor = this,
            started = true,
            InteractionType = InteractionType.Select,
            Transform = transform
        });
    }

    private bool RayCast(out RaycastHit hit)
    {
        return Physics.Raycast(_interactorOriginRay.position, transform.up, out hit, Mathf.Infinity, _interactLayer);
    }

    private bool SphereCast(out RaycastHit hit)
    {
        //TODO: Code SphereCast 
        hit = default;
        return false;
    }

    private void Update()
    {
        

    }

    private void OnDrawGizmos()
    {

        if (Physics.Raycast(_interactorOriginRay.position, transform.up, out var hit, Mathf.Infinity, _interactLayer))
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(_interactorOriginRay.position, hit.point);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_interactorOriginRay.position, _interactorOriginRay.up * 50);
        }


    }
}
