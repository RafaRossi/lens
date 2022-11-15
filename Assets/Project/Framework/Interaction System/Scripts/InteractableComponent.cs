using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableComponent : MonoBehaviour, IInteractableComponent
{
    private IInteractable interactable;
    
    public void Initialize(IInteractable interactable)
    {
        this.interactable = interactable;
    }

    public bool? Interact(Interactor interactor)
    {
        return interactable.Interact(interactor);
    }
}

public interface IInteractableComponent : IInteractable
{
    
}
