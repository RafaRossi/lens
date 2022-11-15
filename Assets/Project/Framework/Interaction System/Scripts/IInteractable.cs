using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public bool CanInteract { get; set; }
    bool? Interact(Interactor interactor);
}
