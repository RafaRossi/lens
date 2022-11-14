using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractableComponent interactableComponent;
    [SerializeField] protected BaseItem item;

    private void Awake()
    {
        InitializeInteractableComponent();
    }

    public void InitializeInteractableComponent()
    {
        interactableComponent.Initialize(this);
    }

    public virtual bool Interact(Interactor interactor)
    {
        PlayerInventory.OnPickItem?.Invoke(item);
        
        Destroy(gameObject);

        return true;
    }

    public BaseItem GetItem() => item;
}
