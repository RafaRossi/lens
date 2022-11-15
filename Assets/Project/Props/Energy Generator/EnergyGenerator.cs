using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyGenerator : TeleportOnInteract
{
    [SerializeField] private Renderer blippingLightRenderer;
    [SerializeField] private Material blippingLightOnMaterial;
    [SerializeField] private Material blippingLightOffMaterial;

    [SerializeField] private bool isOn = false;
    
    [SerializeField] private Color onTurnOnSkyColor;

    private void Start()
    {
        blippingLightRenderer.material = isOn ? blippingLightOnMaterial : blippingLightOffMaterial;
    }

    private void OnEnable()
    {
        GameManager.OnFinishDishWash += ToggleState;
    }

    private void OnDisable()
    {
        GameManager.OnFinishDishWash += ToggleState;
    }

    public override bool? Interact(Interactor interactor)
    {
        if (!CanInteract || isOn) return false;
        
        base.Interact(interactor);
            
        ToggleState();

        CanInteract = false;
        
        GameManager.OnChangeAmbientLight?.Invoke(onTurnOnSkyColor);

        return true;

    }

    public void ToggleState()
    {
        isOn = !isOn;

        blippingLightRenderer.material = isOn ? blippingLightOnMaterial : blippingLightOffMaterial;
    }
}
