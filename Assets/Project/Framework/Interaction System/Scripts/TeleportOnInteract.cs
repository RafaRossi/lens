using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnInteract : Interactable
{
    [SerializeField] protected Transform teleportTarget;

    [SerializeField] protected bool keepSameDistance = true;

    public override bool? Interact(Interactor interactor)
    {
        var controller = interactor.GetComponent<CharacterController>();

        controller.enabled = false;

        var position = interactor.transform.position;

        var objectTransformPosition = transform.position;
        
        
        var difference = keepSameDistance ? new Vector3(position.x - objectTransformPosition.x,
            position.y - objectTransformPosition.y,
            position.z - objectTransformPosition.z) : Vector3.zero;
        
        position = (teleportTarget.position + difference);
        interactor.transform.position = position;

        controller.enabled = true;

        return null;
    }
}
