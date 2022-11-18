using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{
    [SerializeField] protected BaseItem item;

    public override bool? Interact(Interactor interactor)
    {
        PlayerInventory.OnPickItem?.Invoke(item);
        
        Destroy(gameObject);

        return true;
    }

    public BaseItem GetItem() => item;
}
