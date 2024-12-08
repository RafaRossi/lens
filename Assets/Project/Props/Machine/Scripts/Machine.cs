using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    [SerializeField] private List<Pickable> machineObjects = new List<Pickable>();
    [SerializeField] private Transform objectSpawnPoint;
    [SerializeField] private Animator animator;

    [SerializeField] private SimpleDoor doorToUnlock;

    [SerializeField] private TrashCan trashCan;
    [SerializeField] private Lever lever;

    [SerializeField] private List<AudioClip> _audioClips = new List<AudioClip>();
    [SerializeField] private AudioSource narratorAudioSource;

    private int currentMachineIndex = 0;

    private void OnEnable()
    {
        lever.OnLeverPulled += CreateItem;
        
        trashCan.OnItemDestroyed += lever.ResetLever;
        trashCan.OnItemDestroyed += ResetMachine;
    }

    private void OnDisable()
    {
        lever.OnLeverPulled -= CreateItem;
        
        trashCan.OnItemDestroyed -= lever.ResetLever;
        trashCan.OnItemDestroyed -= ResetMachine;
    }
    
    private void CreateItem()
    {
        var item = Instantiate(machineObjects[currentMachineIndex], objectSpawnPoint);

        item.onItemPicked += () =>
        {
            doorToUnlock.OpenDoor();
        };
            
        animator.SetTrigger("Show Object");

        if (currentMachineIndex < machineObjects.Count - 1)
        {
            currentMachineIndex++;
        }
        else
        {
            currentMachineIndex = 0;
        }
    }

    private void ResetMachine()
    {
        animator.SetTrigger("Reset");
        
        doorToUnlock.LockDoor();
    }

    public void PlayAudio()
    {
        if (_audioClips.Count > 0)
        {
            narratorAudioSource.PlayOneShot(_audioClips[0]);

            _audioClips.Remove(_audioClips[0]);
        }
    }
}
