using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CallInteractionContext
{
    public Transform Transform { get; set; }
    public Interactor Actor { get; set; }
    public InteractionType InteractionType { get; set; }
    public bool started { get; set; }
    public bool performed { get; set; }
    public bool canceled { get; set; }
}

public struct PerformedInteractionContext
{
    public Interactable Interactable { get; set; }
    public Transform Transform => Interactable.transform;
    public ActiveInteraction ActiveInteraction { get; set; }
}

public enum ActiveInteraction
{
    On,
    Off,
    Idle
}