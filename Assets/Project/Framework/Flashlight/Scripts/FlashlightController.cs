using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [field:SerializeField] public Flashlight flashlight { get; private set; }

    public void Initialize()
    {
        if (flashlight == null) flashlight = new GameObject().AddComponent<Flashlight>();
    }
    
    public bool Toggle(bool? isOn = null)
    {
        if(isOn == null)
            flashlight.gameObject.SetActive(!flashlight.gameObject.activeSelf);
        else
            flashlight.gameObject.SetActive((bool)isOn);

        return flashlight.gameObject.activeSelf;
    }
}
