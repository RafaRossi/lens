using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UselessEquip : Equipable
{
    public override void Use()
    {
        
    }

    public override bool? Interact(Interactor interactor)
    {
        return null;
    }
}
