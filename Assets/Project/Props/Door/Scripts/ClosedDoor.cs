using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedDoor : Door
{
    protected override bool IsLocked => true;
}
