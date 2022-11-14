using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompositeInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractableComponent interactableComponent;
    
    private List<IInteractable> interactables = new List<IInteractable>();

    [SerializeField] private bool canInteract = true;

    private void Awake()
    {
        InitializeInteractableComponent();
    }

    public void InitializeInteractableComponent()
    {
        interactableComponent.Initialize(this);
    }

    public bool Interact(Interactor interactor)
    {
        if (!canInteract) return false;
        
        foreach (var interactable in interactables)
        {
            interactable.Interact(interactor);
        }

        return true;
    }
}
