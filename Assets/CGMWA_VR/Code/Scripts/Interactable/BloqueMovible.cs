using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueMovible : MonoBehaviour
{
    [SerializeField] private Interactable _interactable;

    [SerializeField]
    private Transform _cube, _onPosition, _offPosition;

    private void OnInteractInteractable(PerformedInteractionContext ctx)
    {
        Transform toMovePos = ctx.ActiveInteraction switch
        {
            ActiveInteraction.On => _onPosition,
            ActiveInteraction.Off => _offPosition,
        };
        
        ChangePos(toMovePos);
    }

    private void ChangePos(Transform newPos)
    {
        _cube.position = newPos.position;
    }

    private void OnEnable()
    {
        _interactable.OnInteract += OnInteractInteractable;
    }

    private void OnDisable()
    {
        _interactable.OnInteract -= OnInteractInteractable;
    }
}
