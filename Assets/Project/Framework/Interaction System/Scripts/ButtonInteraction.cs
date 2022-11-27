using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonInteraction : Interactable
{
    [SerializeField] private bool isPressed = false;
    [SerializeField] private bool isToggleable;

    [SerializeField] private UnityEvent OnTurnOnButton;
    [SerializeField] private UnityEvent OnTurnOffButton;
    
    public override bool? Interact(Interactor interactor)
    {
        if (isToggleable)
        {
            if (isPressed)
            {
                TurnOff();
            }
            else
            {
                TurnOn();
            }
        }
        else
        {
            TurnOn();
        }
        
        return null;
    }

    private void TurnOn()
    {
        OnTurnOnButton?.Invoke();
    }

    private void TurnOff()
    {
        OnTurnOffButton?.Invoke();
    }
}
