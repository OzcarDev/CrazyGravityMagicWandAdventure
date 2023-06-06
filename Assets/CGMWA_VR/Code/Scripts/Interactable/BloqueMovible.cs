using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BloqueMovible : MonoBehaviour
{
    [SerializeField] private Interactable _interactable;

    [SerializeField]
    private Transform _cube, _onPosition, _offPosition;

    private Tween _moveTween = null;

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
        if(_moveTween.IsActive())
            _moveTween.Kill();

        _moveTween = _cube.DOMove(newPos.position, 0.75f);
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
