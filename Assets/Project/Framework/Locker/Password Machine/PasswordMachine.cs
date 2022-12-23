using System;
using Cinemachine;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PasswordMachine : Interactable
{
    [SerializeField] private string password = string.Empty;
    [SerializeField] private TMP_InputField passwordInputField;

    public Action OnStartInteract = delegate {  };
    public Action OnStopInteract = delegate {  };
    
    [SerializeField] private UnityEvent onEnterRightPassword = new UnityEvent();
    [SerializeField] private UnityEvent onEnterWrongPassword = new UnityEvent();

    [SerializeField] private CinemachineVirtualCamera cinemachineVirtualCamera;

    private void Update()
    {
        if (Input.GetKeyDown(PlayerInput.CancelInteractionKeyCode) && !CanInteract && PlayerController.CurrentPlayerState == PlayerState.Interacting)
        {
            Deactivate();
        }
    }

    public void EnterKey(string key)
    {
        if(passwordInputField.text.Length >= passwordInputField.characterLimit) return;
        
        passwordInputField.text += key;
    }

    public void ClearInput()
    {
        passwordInputField.text = string.Empty;
    }

    public void EraseKey()
    {
        if(passwordInputField.text.Length <= 0) return;
        
        passwordInputField.text = passwordInputField.text.Remove(passwordInputField.text.Length - 1);
    }

    public void ConfirmPassword()
    {
        if (passwordInputField.text.Equals(password))
        {
            onEnterRightPassword?.Invoke();
            
            Complete();

            enabled = false;
            
            return;
        }
            
        onEnterWrongPassword?.Invoke();
    }

    public override bool? Interact(Interactor interactor)
    {
        Activate();
        
        return null;
    }

    private void Activate()
    {
        CanInteract = false;

        cinemachineVirtualCamera.enabled = true;

        PlayerController.CurrentPlayerState = PlayerState.Interacting;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
        OnStartInteract?.Invoke();
    }

    private void Deactivate()
    {
        CanInteract = true;

        Complete();
    }

    private void Complete()
    {
        cinemachineVirtualCamera.enabled = false;
        
        PlayerController.CurrentPlayerState = PlayerState.Idle;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        OnStopInteract?.Invoke();
    }
}
