using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ExchangeItemBehaviour : Interactable, IItemInteraction
{
    [SerializeField] private BaseItem enterItem;
    [SerializeField] private UsableItem exitItem;

    public override bool? Interact(Interactor interactor)
    {
        if (interactor.GetCurrentEquippedItem == null) return false;
        
        if (!Interact(interactor.GetCurrentEquippedItem.GetItem())) return false;
            
        PlayerInventory.OnRemoveItem?.Invoke(enterItem);
                
        PlayerInventory.OnPickItem?.Invoke(exitItem);
        return true;

    }
    
    public bool Interact(BaseItem item)
    {
        return item == enterItem;
    }
}