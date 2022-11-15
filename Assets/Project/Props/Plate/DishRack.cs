using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DishRack : Interactable, IItemInteraction
{
    [SerializeField] private BaseItem cleanPlate;

    [SerializeField] private Transform[] plates;
    
    [SerializeField] private Color onFinishDishWashSkyColor;

    private int plateCount = 0;

    public override bool? Interact(Interactor interactor)
    {
        if (interactor.GetCurrentEquippedItem == null) return false;
        
        if (!Interact(interactor.GetCurrentEquippedItem.GetItem())) return false;
        
        PlayerInventory.OnRemoveItem?.Invoke(cleanPlate);

        if (plateCount >= plates.Length) return true;
        
        plates[plateCount].gameObject.SetActive(true);
        plateCount++;

        if (plateCount == 5)
        {
            GameManager.OnFinishDishWash?.Invoke();
            GameManager.OnChangeAmbientLight?.Invoke(onFinishDishWashSkyColor);
        }

        return true;
    }

    public bool Interact(BaseItem item)
    {
        return item == cleanPlate;
    }
}
