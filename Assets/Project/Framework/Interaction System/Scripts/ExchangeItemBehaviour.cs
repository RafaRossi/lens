using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

public class ExchangeItemBehaviour : Interactable, IItemInteraction
{
    [SerializeField] private List<BaseItem> enterItem = new List<BaseItem>();
    [SerializeField] private UsableItem exitItem;

    public override bool? Interact(Interactor interactor)
    {
        if (interactor.GetCurrentEquippedItem == null) return false;

        var item = interactor.GetCurrentEquippedItem.GetItem();
        
        if (!Interact(item)) return false;
            
        PlayerInventory.OnRemoveItem?.Invoke(item);
        
        if(exitItem != null) PlayerInventory.OnPickItem?.Invoke(exitItem);
        
        if (audioSource != null)
            audioSource.Play();
        
        return true;
    }
    
    public bool Interact(BaseItem item)
    {
        return enterItem.Contains(item);
    }
}
