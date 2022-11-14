using System;
using UnityEngine;

public abstract class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractableComponent interactableComponent;
    [SerializeField] protected Animator animator;

    protected virtual string ClosedAnimationName { get; set; } = "door_locked";

    protected virtual bool IsLocked { get; set; } = false;

    private void Awake()
    {
        if (animator == null) animator = GetComponent<Animator>();

        InitializeInteractableComponent();
    }

    public void InitializeInteractableComponent()
    {
        interactableComponent.Initialize(this);
    }

    public virtual bool Interact(Interactor interactor)
    {
        if(IsLocked) animator.CrossFade(ClosedAnimationName, 0f);
        return IsLocked;
    }
}
