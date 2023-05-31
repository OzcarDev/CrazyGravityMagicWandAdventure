using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInteractable : Interactable
{
    public override event Action<PerformedInteractionContext> OnInteract;
    [SerializeField] private Lever _onLever, _offLever;

    private ActiveInteraction _activeInteraction = ActiveInteraction.Idle;

    private void OnEnable()
    {
        _onLever.OnTrigger.AddListener(TriggerOnLever);
        _offLever.OnTrigger.AddListener(TriggerOffLever);
    }

    private void OnDisable()
    {
        _onLever.OnTrigger.AddListener(TriggerOnLever);
        _offLever.OnTrigger.AddListener(TriggerOffLever);
    }

    private void TriggerLevel(bool isOn)
    {
        _activeInteraction = isOn ? ActiveInteraction.On : ActiveInteraction.Off;
        Interact(default);
    }

    private void TriggerOnLever() => TriggerLevel(true);
    private void TriggerOffLever() => TriggerLevel(false);

    public override void Interact(CallInteractionContext ctx)
    {
        OnInteract?.Invoke(new PerformedInteractionContext
        {
            Interactable = this,
            ActiveInteraction = _activeInteraction
        });   
    }
}
