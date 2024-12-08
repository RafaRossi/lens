using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Equipable : Interactable
{
    [SerializeField] protected UsableItem item;
    
    public Action OnItemEquiped = delegate {  };
    
    public abstract void Use();

    private void OnEnable()
    {
        PlayerInventory.OnItemFullyRemoved += OnItemRemovedFromInventory;
    }

    private void OnDisable()
    {
        PlayerInventory.OnItemFullyRemoved -= OnItemRemovedFromInventory;
    }

    public UsableItem GetItem() => item;

    protected virtual void OnItemRemovedFromInventory(BaseItem item)
    {
        if(GetItem() == item) Destroy(gameObject);
    }
}
