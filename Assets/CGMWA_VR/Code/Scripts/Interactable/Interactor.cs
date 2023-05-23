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

    public void CheckRaycastInteraction()
    {
        if (!RayCast(out var hit)) return;

        var interactable = hit.transform.GetComponent<Interactable>();
        
        if(!interactable) return;
        
        interactable.Interact(new InteractionContext()
        {
            Actor = this,
            started = true,
            InteractionType = InteractionType.Select,
            Transform = transform
        });
    }

    private bool RayCast(out RaycastHit hit)
    {
        return Physics.Raycast(_interactorOriginRay.position, transform.up, out hit, Mathf.Infinity);
    }

    private bool SphereCast(out RaycastHit hit)
    {
        //TODO: Code SphereCast 
        hit = default;
        return false;
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
