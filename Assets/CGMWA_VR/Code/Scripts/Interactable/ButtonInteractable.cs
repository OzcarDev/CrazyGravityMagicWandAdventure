using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonInteractable : Interactable
{
    public override event Action<PerformedInteractionContext> OnInteract;

    [SerializeField] 
    private bool _isOnHold = false;

    private ActiveInteraction _currentInteraction = ActiveInteraction.Idle;

    public void OnStartedInteract()
    {
        if (_isOnHold)
        {
            _currentInteraction = ActiveInteraction.On;
        }
        else
        {
            _currentInteraction = _currentInteraction switch
            {
                ActiveInteraction.Off => ActiveInteraction.On,
                ActiveInteraction.On => ActiveInteraction.Off,
                _ => ActiveInteraction.On
            };
        }

        Interact(default);
    }

    public void OnEndInteract()
    {
        if (!_isOnHold) return;
        _currentInteraction = ActiveInteraction.Off;
        Interact(default);
    }
    
    public override void Interact(CallInteractionContext ctx)
    {
        OnInteract?.Invoke(new PerformedInteractionContext
        {
            Interactable = this,
            ActiveInteraction = _currentInteraction
        });
    }
}
