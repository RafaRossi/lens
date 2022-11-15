using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerController : MonoBehaviour
{
    #region PlayerInputs

    [SerializeField] private KeyCode interactionKeyCode = KeyCode.E;
    [SerializeField] private KeyCode useItemKeyCode = KeyCode.Mouse0;
    [SerializeField] private KeyCode sprintKeyCode = KeyCode.LeftShift;
    [SerializeField] private KeyCode flashlightKeyCode = KeyCode.F;

    #endregion

    #region Components

    [SerializeField] private CharacterController controller;
    [SerializeField] private Interactor interactor;
    [SerializeField] private EquipController equipController;

    [SerializeField] private FlashlightController flashlightController;

    [SerializeField] private Camera _camera;

    #endregion

    #region Movement

    [SerializeField] private float normalSpeed = 8f;
    [SerializeField] private float sprintSpeed = 10f;

    private float speed = 0f;

    private Vector3 direction = Vector3.zero;

    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(interactionKeyCode))
        {
            interactor.Interact();
        }

        if (Input.GetKeyDown(useItemKeyCode))
        {
            interactor.UseItem();
        }

        if (Input.GetKeyDown(flashlightKeyCode))
        {
            flashlightController.Toggle();
        }

        speed = Input.GetKey(sprintKeyCode) ? sprintSpeed : normalSpeed;
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
