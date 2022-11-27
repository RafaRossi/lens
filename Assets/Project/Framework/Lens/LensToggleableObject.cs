using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LensToggleableObject : MonoBehaviour
{
    [SerializeField] private ToggleableObject[] toggleableObjects;

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
        foreach (var toggleableObject in toggleableObjects)
        {
            if(toggleableObject.objectToToggle == null) return;
        
            toggleableObject.objectToToggle.SetActive(toggleableObject.lensList.Contains(len) ? toggleableObject.activeState : !toggleableObject.activeState);
        }
    }
}

[Serializable]
public struct ToggleableObject
{
    public List<Lens> lensList;
    public GameObject objectToToggle;
    public bool activeState;
}