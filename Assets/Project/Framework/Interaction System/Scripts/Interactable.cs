using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] protected InteractableComponent interactableComponent;

    [SerializeField] private string interactionText = string.Empty;
    
    private void Awake()
    {
        InitializeInteractableComponent();
    }

    public void InitializeInteractableComponent()
    {
        interactableComponent.Initialize(this);
    }

    public bool CanInteract { get => interactableComponent.CanInteract; set => interactableComponent.CanInteract = value; }
    
    public abstract bool? Interact(Interactor interactor);

    public string GetInteractionText() => interactionText;
}
