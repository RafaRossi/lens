using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemSlot> carryableItems = new List<ItemSlot>();
    public List<ItemSlot> usableItems = new List<ItemSlot>();

    public Equipable currentEquippedItem = null;
    
    public static Action<BaseItem> OnPickItem = delegate(BaseItem item) {  };
    public static Action<UsableItem> OnCollectedItem = delegate(UsableItem item) {  };

    public static Func<BaseItem, bool> OnRemoveItem;
    public static Action<BaseItem> OnItemFullyRemoved = delegate(BaseItem item) {  };

    private void OnEnable()
    {
        OnPickItem += PickItem;
        OnRemoveItem += RemoveItem;
    }

    private void OnDisable()
    {
        OnPickItem -= PickItem;
        OnRemoveItem -= RemoveItem;
    }

    private void PickItem(BaseItem item)
    {
        switch (item.ItemType)
        {
            case ItemType.Default:
                AddToInventory(carryableItems, item);
                break;
            
            case ItemType.Usable:
                AddToInventory(usableItems, item as UsableItem);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private bool AddToInventory(List<ItemSlot> slots, BaseItem item)
    {
        foreach (var slot in slots.Where(slot => slot.item == item))
        {
            slot.itemAmount++;
            
            return true;
        }

        slots.Add(new ItemSlot(item));

        return false;
    }
    
    private void AddToInventory(List<ItemSlot> slots, UsableItem item)
    {
        if(!AddToInventory(slots, item as BaseItem))
            OnCollectedItem?.Invoke(item);
    }

    private bool RemoveItem(BaseItem item)
    {
        return item.ItemType switch
        {
            ItemType.Default => RemoveFromInventory(carryableItems, item),
            ItemType.Usable => RemoveFromInventory(usableItems, item),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private bool RemoveFromInventory(List<ItemSlot> slots, BaseItem item)
    {
        foreach (var slot in slots.Where(slot => slot.item == item))
        {
            slot.itemAmount--;

            if (!(slot.itemAmount <= 0)) return false;
            slots.Remove(slot);
            return true;

        }
        
        return false;
    }
}

[Serializable]
public class ItemSlot
{
    public BaseItem item;
    
    public readonly ItemType ItemType;
    public float itemAmount;

    public ItemSlot(BaseItem item)
    {
        this.item = item;
        ItemType = item.ItemType;

        itemAmount = 1;
    }
}
