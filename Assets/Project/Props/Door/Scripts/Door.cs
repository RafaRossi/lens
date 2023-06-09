using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Door : Interactable
{
    [SerializeField] protected Animator animator;

    [SerializeField] protected List<AudioClip> openSounds;
    [SerializeField] protected List<AudioClip> closeSound;
    [SerializeField] protected List<AudioClip> lockedSound;

    protected virtual string ClosedAnimationName { get; set; } = "door_locked";

    public virtual bool IsLocked { get; protected set; } = false;
    

    public override bool? Interact(Interactor interactor)
    {
        if (IsLocked)
        {
            animator.CrossFade(ClosedAnimationName, 0f);
            PlayRandomSound(lockedSound);
        }
        
        return IsLocked;
    }

    protected void PlayRandomSound(List<AudioClip> clips)
    {
        if (clips == null || !clips.Any() || audioSource == null)
            return;

        audioSource.clip = clips[Random.Range(0, clips.Count - 1)];
        audioSource.pitch = Random.Range(0.75f, 1.25f);
        audioSource.Play();
    }
}
