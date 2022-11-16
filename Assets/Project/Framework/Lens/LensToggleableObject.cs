using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensToggleableObject : MonoBehaviour
{
    [SerializeField] private List<Lens> lensList = new List<Lens>();
    [SerializeField] private GameObject objectToToggle;
    [SerializeField] private bool active;

    private void Start()
    {
        LensController.OnLensEquipped += OnLensChanged;
    }

    private void OnDestroy()
    {
        LensController.OnLensEquipped -= OnLensChanged;
    }

    private void OnLensChanged(Lens len)
    {
        if(objectToToggle == null) return;
        
        objectToToggle.SetActive(lensList.Contains(len) ? active : !active);
    }
}