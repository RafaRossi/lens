using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardKeyEnter : KeyboardKey
{
    protected override void EnterKey()
    {
        if (!CanInteract) return;
        
        passwordMachine.ConfirmPassword();
            
        onKeyPressed?.Invoke();
    }
}