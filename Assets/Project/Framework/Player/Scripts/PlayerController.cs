using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerController : MonoBehaviour
{
    #region Components

    [SerializeField] private CharacterController controller;
    [SerializeField] private Interactor interactor;
    [SerializeField] private EquipController equipController;

    [SerializeField] private FlashlightController flashlightController;

    [SerializeField] private Camera _camera;

    #endregion

    #region Movement

    [SerializeField] private float normalSpeed = 5f;
    [SerializeField] private float sprintSpeed = 12f;

    private float speed = 0f;

    private Vector3 direction = Vector3.zero;

    #endregion

    public static PlayerState CurrentPlayerState = PlayerState.Idle;

    private void Update()
    {
        if(CurrentPlayerState != PlayerState.Idle) return;
        
        if (Input.GetKeyDown(PlayerInput.InteractionKeyCode))
        {
            interactor.Interact();
        }

        if (Input.GetKeyDown(PlayerInput.UseItemKeyCode))
        {
            interactor.UseItem();
        }

        if (Input.GetKeyDown(PlayerInput.FlashlightKeyCode))
        {
            flashlightController.Toggle();
        }

        speed = Input.GetKey(PlayerInput.SprintKeyCode) ? sprintSpeed : normalSpeed;
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void LateUpdate()
    {
        Move();
    }

    private void Move()
    {
        var velocity = _camera.transform.TransformDirection(direction).normalized * (speed * Time.deltaTime);
        velocity.y = 0f;

        velocity.y += Physics.gravity.y * Time.deltaTime;
        
        controller.Move(velocity);
    }
}

public enum PlayerState
{
    Idle,
    Interacting
}

public struct PlayerInput
{
    public static KeyCode InteractionKeyCode => KeyCode.Mouse0;
    public static KeyCode UseItemKeyCode => KeyCode.E;
    public static KeyCode SprintKeyCode => KeyCode.LeftShift;
    public static KeyCode FlashlightKeyCode => KeyCode.F;
    public static KeyCode CancelInteractionKeyCode => KeyCode.Escape;
}