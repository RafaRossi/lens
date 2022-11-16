using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PickItemBehaviour : Interactable
{
    [SerializeField] private BaseItem item;
    
    public override bool? Interact(Interactor interactor)
    {
        PlayerInventory.OnPickItem.Invoke(item);
        
        if (audioSource != null)
            audioSource.Play();

        return true;
    }
}
