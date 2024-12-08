using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyboardKeyErase : KeyboardKey
{
    protected override void EnterKey()
    {
        if (!CanInteract) return;
        
        passwordMachine.EraseKey();
            
        onKeyPressed?.Invoke();
    }
}
