using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : Interactable
{
    [SerializeField] protected BaseItem item;

    public Action onItemPicked = null;

    public override bool? Interact(Interactor interactor)
    {
        PlayerInventory.OnPickItem?.Invoke(item);
        
        onItemPicked?.Invoke();
        
        Destroy(gameObject);

        return true;
    }

    public BaseItem GetItem() => item;
}
