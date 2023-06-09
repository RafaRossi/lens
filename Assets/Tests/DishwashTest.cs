using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class DishwashTest
{
    [UnityTest]
    public IEnumerator CheckIfPlayerMoves()
    {
        var obj = new GameObject();

        var startedPosition = obj.transform.position;
        var characterMovement = obj.AddComponent<CharacterController>();

        characterMovement.Move(Vector3.forward);
        
        yield return new WaitForEndOfFrame();
        
        Assert.AreNotEqual(characterMovement.gameObject.transform.position, startedPosition);
    }
    
    [UnityTest]
    public IEnumerator TryOpenDoor()
    {
        var obj = new GameObject();
        
        var door = obj.AddComponent<SimpleDoor>();
        door.Interact();
        
        Assert.AreNotEqual(door.IsLocked, door.isOpen);
        
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator AddItemToInventory()
    {
        var playerInventory = new GameObject().AddComponent<PlayerInventory>();
        
        var item = ScriptableObject.CreateInstance<Item>();

        PlayerInventory.OnPickItem(item);
        
        Assert.Contains(item, playerInventory.GetInventory(item).Select(i => i.item).ToList());
        
        yield return null;
    }
    
    [UnityTest]
    public IEnumerator ToggleFlashlight()
    {
        var flashlightController = new GameObject().AddComponent<FlashlightController>();
        flashlightController.Initialize();

        var flashlightState = flashlightController.flashlight.gameObject.activeSelf;

        flashlightController.Toggle();
        
        Assert.AreNotEqual(flashlightState, flashlightController.flashlight.gameObject.activeSelf);
        
        yield return null;
    }
}
