using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform targetPosition;

    [SerializeField] private bool keepSameDistance = true;

    public void Teleport()
    {
        controller.enabled = false;

        var position = controller.transform.position;

        var objectTransformPosition = transform.position;
        
        
        var difference = keepSameDistance ? new Vector3(position.x - objectTransformPosition.x,
            position.y - objectTransformPosition.y,
            position.z - objectTransformPosition.z) : Vector3.zero;
        
        position = (targetPosition.position + difference);
        controller.transform.position = position;

        controller.enabled = true;
    }

    public void TeleportAfterTime(float time)
    {
        Invoke("Teleport", time);
    }
}
