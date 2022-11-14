using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    void InitializeInteractableComponent();
    bool Interact(Interactor interactor);
}
