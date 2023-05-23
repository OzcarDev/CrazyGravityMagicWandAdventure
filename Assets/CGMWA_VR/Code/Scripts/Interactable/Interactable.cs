using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected InteractionType _InteractiosAllowed;

    public abstract void Interact(InteractionContext ctx);
}
