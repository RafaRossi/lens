using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardKeyClear : KeyboardKey
{
    protected override void EnterKey()
    {
        if (!CanInteract) return;
        
        passwordMachine.ClearInput();
            
        onKeyPressed?.Invoke();
    }
}
