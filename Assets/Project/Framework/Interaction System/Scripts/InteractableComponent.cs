using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableComponent : MonoBehaviour, IInteractableComponent
{
    private IInteractable interactable;

    [SerializeField] private UnityEvent<bool> OnInteract = new UnityEvent<bool>();

    [SerializeField] private bool canInteract = true;
    public bool CanInteract { get => canInteract; set => canInteract = value; }
    
    public void Initialize(IInteractable interactable)
    {
        this.interactable = interactable;
    }

    public bool? Interact(Interactor interactor)
    {
        if (!CanInteract) return false;
        
        var interaction = interactable.Interact(interactor);
        
        if(interaction == true) OnInteract?.Invoke(true);
        
        return interaction;
    }
}

public interface IInteractableComponent : IInteractable
{
    
}
