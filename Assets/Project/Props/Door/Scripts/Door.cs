using System;
using UnityEngine;

public abstract class Door : Interactable
{
    [SerializeField] protected Animator animator;

    protected virtual string ClosedAnimationName { get; set; } = "door_locked";

    protected virtual bool IsLocked { get; set; } = false;
    

    public override bool? Interact(Interactor interactor)
    {
        if(IsLocked) animator.CrossFade(ClosedAnimationName, 0f);
        return IsLocked;
    }
}
