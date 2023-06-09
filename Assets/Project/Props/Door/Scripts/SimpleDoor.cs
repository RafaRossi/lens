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
    [SerializeField] private bool removeKeyFromInventory = false;

    [SerializeField] private GameObject interiorDoor;

    [SerializeField] private AnimationCurve openCurve;
    [SerializeField] private AnimationCurve closeCurve;
    
    private float openDoorTime = 1f;
    private float closeDoorTime = 0.4f;

    private float intialInteriorDoorRotation = 0f;

    public bool isOpen = false;

    private Coroutine rotatingDoor;
    
    private void Start()
    {
        intialInteriorDoorRotation = interiorDoor == null ? 0 : interiorDoor.transform.eulerAngles.y;
        
        IsLocked = doorInitialLockedState;
    }

    public override bool? Interact(Interactor interactor)
    {
        if (rotatingDoor != null)
        {
            StopCoroutine(rotatingDoor);
            audioSource?.Stop();
        }

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

        if (removeKeyFromInventory) PlayerInventory.OnRemoveItem?.Invoke(doorKey);
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

        PlayRandomSound(openSounds);

        float diff;
        var doorTime = isOpen ? openDoorTime : closeDoorTime;
        var doorCurve = isOpen ? openCurve : closeCurve;
        var initialY = interiorDoorRotation.y;

        do
        {
            interiorDoorRotation.y = Mathf.Lerp(initialY, desiredRotation, doorCurve.Evaluate(elapsedTime / doorTime));

            elapsedTime += Time.deltaTime;

            interiorDoor.transform.eulerAngles = interiorDoorRotation;

            diff = Mathf.Abs(interiorDoorRotation.y - desiredRotation);

            yield return null;
        } while (diff > 0.5f);
        
        if (!isOpen)
            PlayRandomSound(closeSound);
    }

    public bool Interact(BaseItem item)
    {
        //var behaviour = itemInteractionBehaviours.FirstOrDefault(behaviour => behaviour.item == item);

        if (item != doorKey) return false;
        
        UnlockDoor();

        return true;
    }

    public void Interact()
    {
        if (!IsLocked)
        {
            isOpen = !isOpen;
        }
    }
}
