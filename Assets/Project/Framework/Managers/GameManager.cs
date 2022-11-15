using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static Action<Color> OnChangeAmbientLight = delegate(Color color) {  };
    public static Action OnFinishDishWash = delegate {  };
    [SerializeField] private UnityEvent OnFinishDishWashEvent = new UnityEvent();
    [SerializeField] private UnityEvent<Color> OnChangeAmbientLightEvent = new UnityEvent<Color>();

    private void OnEnable()
    {
        OnFinishDishWash += FinishDishWash;

        OnChangeAmbientLight += ChangeAmbientLight;
    }

    private void OnDisable()
    {
        OnFinishDishWash -= FinishDishWash;
        
        OnChangeAmbientLight -= ChangeAmbientLight;
    }

    private void FinishDishWash()
    {
        OnFinishDishWashEvent?.Invoke();
    }

    private void ChangeAmbientLight(Color color)
    {
        RenderSettings.ambientLight = color;
        
        OnChangeAmbientLightEvent?.Invoke(color);
    }

    private void OnApplicationFocus(bool hasFocus)
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
