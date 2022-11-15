using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnInteract : Interactable
{
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private bool keepSameDistance = true;

    public override bool? Interact(Interactor interactor)
    {
        if (!keepSameDistance) return true;
        
        var controller = interactor.GetComponent<CharacterController>();

        controller.enabled = false;

        var position = interactor.transform.position;
            
        var difference = new Vector3(position.x - transform.position.x,
            position.y - transform.position.y,
            position.z - transform.position.z);
        position = (teleportTarget.position + difference);
        interactor.transform.position = position;

        controller.enabled = true;

        return true;
    }
}
