using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : Equipable
{
    public override void Use()
    {
        var fullyRemoved = PlayerInventory.OnRemoveItem?.Invoke(item) ?? false;

        Debug.Log("Usando item: " + item.name);
        
        if (fullyRemoved)
        {
            Destroy(gameObject);
        }
    }
}
