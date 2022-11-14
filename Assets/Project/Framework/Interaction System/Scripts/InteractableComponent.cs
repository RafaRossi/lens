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

    public void Interact(Interactor interactor)
    {
        interactable.Interact(interactor);
    }
}

public interface IInteractableComponent
{
    void Initialize(IInteractable interactable);
    void Interact(Interactor interactor);
}
