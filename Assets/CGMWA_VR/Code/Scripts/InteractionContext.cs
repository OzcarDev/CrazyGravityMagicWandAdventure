using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InteractionContext
{
    public Interactor Actor { get; set; }
    public InteractionType InteractionType { get; set; }
    public Transform Transform { get; set; }
    public bool started { get; set; }
    public bool performed { get; set; }
    public bool canceled { get; set; }
}
