using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickItemBehaviour : Interactable
{
    [SerializeField] private BaseItem item;
    public override bool? Interact(Interactor interactor)
    {
        PlayerInventory.OnPickItem.Invoke(item);

        return true;
    }
}
