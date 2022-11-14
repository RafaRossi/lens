using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipable : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractableComponent interactableComponent;
    [SerializeField] protected UsableItem item;
    public abstract void Use();

    private void Awake()
    {
        InitializeInteractableComponent();
    }

    public UsableItem GetItem() => item;

    public void InitializeInteractableComponent()
    {
        interactableComponent.Initialize(this);
    }

    public bool Interact(Interactor interactor)
    {
        PlayerInventory.OnPickItem?.Invoke(item);
        
        Destroy(gameObject);
        return true;
    }
}
