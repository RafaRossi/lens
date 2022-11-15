using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableComponent : MonoBehaviour, IInteractableComponent
{
    private IInteractable interactable;

    [SerializeField] private UnityEvent<bool> OnInteract = new UnityEvent<bool>();
    
    public bool CanInteract { get; set; }
    
    public void Initialize(IInteractable interactable)
    {
        this.interactable = interactable;
    }

    public bool? Interact(Interactor interactor)
    {
        var interaction = interactable.Interact(interactor);
        OnInteract?.Invoke(interaction != null && (bool)interaction);
        return interaction;
    }
}

public interface IInteractableComponent : IInteractable
{
    
}
