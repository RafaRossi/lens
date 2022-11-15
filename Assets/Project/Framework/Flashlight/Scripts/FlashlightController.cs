using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] private Flashlight flashlight;

    public bool Toggle(bool? isOn = null)
    {
        if(isOn == null)
            flashlight.gameObject.SetActive(!flashlight.gameObject.activeSelf);
        else
            flashlight.gameObject.SetActive((bool)isOn);

        return flashlight.gameObject.activeSelf;
    }
}
