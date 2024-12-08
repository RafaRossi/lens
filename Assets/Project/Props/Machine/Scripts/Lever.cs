using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    [SerializeField] private Animator animator;
    
    public Action OnLeverPulled = delegate {  };
    public override bool? Interact(Interactor interactor)
    {
        if (!CanInteract) return null;
        
        PullTheLever();
            
        return null;
    }

    private void PullTheLever()
    {
        CanInteract = false;
        animator.SetTrigger("Toggle");
    }

    public void ResetLever()
    {
        animator.SetTrigger("Reset");

        CanInteract = true;
    }

    public void CallOnLeverPulled()
    {
        OnLeverPulled?.Invoke();
    }
}
