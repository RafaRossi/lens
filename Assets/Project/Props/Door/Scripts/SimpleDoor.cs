using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleDoor : Door, IItemInteraction
{
    //public List<ItemInteractionBehaviour> itemInteractionBehaviours = new List<ItemInteractionBehaviour>();

    [SerializeField] private bool doorInitialLockedState = true;
    [SerializeField] private UsableItem doorKey;

    [SerializeField] private GameObject interiorDoor;
    private float openDoorTime = 10f;

    private float intialInteriorDoorRotation = 0f;

    private bool isOpen = false;

    private Coroutine rotatingDoor;
    
    private void Start()
    {
        intialInteriorDoorRotation = interiorDoor.transform.eulerAngles.y;
        
        IsLocked = doorInitialLockedState;
    }

    public override bool? Interact(Interactor interactor)
    {
        if(rotatingDoor != null) StopCoroutine(rotatingDoor);

        var doorTransformDirection = transform.TransformDirection(Vector3.forward);
        var playerTransformDirection = interactor.transform.position - transform.position;

        var dot = Vector3.Dot(doorTransformDirection, playerTransformDirection);

        if (interactor.GetCurrentEquippedItem != null)
        {
            if (Interact(interactor.GetCurrentEquippedItem.GetItem()))
            {
                rotatingDoor = StartCoroutine(OpenDoor(dot));
                return true;
            }
        }
        if (base.Interact(interactor) ?? false) return false;

        rotatingDoor = StartCoroutine(OpenDoor(dot));
        return true;
    }

    private void UnlockDoor()
    {
        IsLocked = false;
    }

    private IEnumerator OpenDoor(float dot)
    {
        var elapsedTime = 0f;
        
        var desiredRotation = isOpen ? intialInteriorDoorRotation : intialInteriorDoorRotation - (90 * Mathf.Sign(dot)); 
        var interiorDoorRotation = interiorDoor.transform.eulerAngles;

        isOpen = !isOpen;

        if (Mathf.Abs(interiorDoorRotation.y - desiredRotation) > 180f)
        {
            interiorDoorRotation.y -= 360f * Mathf.Sign(interiorDoorRotation.y - desiredRotation);
        }
        
        while (Mathf.Abs(interiorDoorRotation.y - desiredRotation) > 0.5f)
        {
            interiorDoorRotation.y = Mathf.Lerp(interiorDoorRotation.y, desiredRotation, elapsedTime/openDoorTime);

            elapsedTime += Time.deltaTime;
            
            interiorDoor.transform.eulerAngles = interiorDoorRotation;

            yield return null;
        }
    }

    public bool Interact(BaseItem item)
    {
        //var behaviour = itemInteractionBehaviours.FirstOrDefault(behaviour => behaviour.item == item);

        if (item != doorKey) return false;
        
        UnlockDoor();

        return true;
    }
}