using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : Door
{
    public override bool IsLocked => true;
}
