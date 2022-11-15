using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeInteraction : Interactable, IInteractable
{
    private List<IInteractable> interactables = new List<IInteractable>();

    [SerializeField] private bool canInteract = true;
    

    public override bool? Interact(Interactor interactor)
    {
        if (!canInteract) return false;
        
        foreach (var interactable in interactables)
        {
            interactable.Interact(interactor);
        }

        return true;
    }
}
