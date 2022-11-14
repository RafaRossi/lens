using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractableComponent interactableComponent;

    [SerializeField] private Transform teleportTarget;
    [SerializeField] private bool keepSameDistance = true;

    private void Awake()
    {
        InitializeInteractableComponent();
    }

    public void InitializeInteractableComponent()
    {
        interactableComponent.Initialize(this);
    }

    public bool Interact(Interactor interactor)
    {
        if (keepSameDistance)
        {
            var controller = interactor.GetComponent<CharacterController>();

            controller.enabled = false;

            var difference = new Vector3(interactor.transform.position.x - transform.position.x,
                interactor.transform.position.y - transform.position.y,
                interactor.transform.position.z - transform.position.z);
            interactor.transform.position = (teleportTarget.position + difference);

            controller.enabled = true;
        }

        return true;
    }
}
