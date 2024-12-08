using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public abstract class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] protected InteractableComponent interactableComponent;

    [SerializeField] private string interactionText = string.Empty;
    
    [SerializeField] [CanBeNull] protected AudioSource audioSource;
    
    protected virtual void Awake()
    {
        InitializeInteractableComponent();
    }

    public void InitializeInteractableComponent()
    {
        if (interactableComponent == null) interactableComponent = gameObject.AddComponent<InteractableComponent>();
        interactableComponent.Initialize(this);
    }

    public bool CanInteract { get => interactableComponent.CanInteract; set => interactableComponent.CanInteract = value; }
    
    public abstract bool? Interact(Interactor interactor);

    public string GetInteractionText() => interactionText;
}
