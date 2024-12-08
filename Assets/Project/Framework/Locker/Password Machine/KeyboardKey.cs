using System;
using UnityEngine;
using UnityEngine.Events;

public class KeyboardKey : MonoBehaviour
{
    [SerializeField] protected PasswordMachine passwordMachine;
    
    [SerializeField] private string inputKey = string.Empty;

    [SerializeField] protected UnityEvent onKeyPressed = new UnityEvent();

    [SerializeField] protected ClickableComponent clickableComponent;

    public bool CanInteract { get; set; } = false;

    private void OnEnable()
    {
        passwordMachine.OnStartInteract += Activate;
        passwordMachine.OnStopInteract += Deactivate;

        clickableComponent.OnClick += EnterKey;
    }

    private void OnDisable()
    {
        passwordMachine.OnStartInteract -= Activate;
        passwordMachine.OnStopInteract -= Deactivate;
        
        clickableComponent.OnClick -= EnterKey;
    }

    private void Activate()
    {
        CanInteract = true;
    }
    
    private void Deactivate()
    {
        CanInteract = false;
    }

    protected virtual void EnterKey()
    {
        if (!CanInteract) return;
        
        passwordMachine.EnterKey(inputKey);
            
        onKeyPressed?.Invoke();
    }

}
