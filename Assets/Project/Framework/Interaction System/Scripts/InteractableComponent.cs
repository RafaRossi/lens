using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableComponent : MonoBehaviour, IInteractableComponent
{
    private IInteractable interactable;

    [SerializeField] private UnityEvent OnInteract = new UnityEvent();
    
    public void Initialize(IInteractable interactable)
    {
        this.interactable = interactable;
    }

    public bool? Interact(Interactor interactor)
    {
        OnInteract?.Invoke();
        return interactable.Interact(interactor);
    }
}

public interface IInteractableComponent : IInteractable
{
    
}
