using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectOutOfSight : MonoBehaviour
{
    [SerializeField] private GameObject objectToChange = null;
    public bool IsActive { get; set; } = false;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        if(!IsActive) return;

        if (_renderer.isVisible) return;
        
        objectToChange.SetActive(true);
            
        gameObject.SetActive(false);
    }
}
