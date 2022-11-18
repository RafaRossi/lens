using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static Action<Color> OnChangeAmbientLight = delegate(Color color) {  };
    public static Action OnFinishDishWash = delegate {  };
    public static Action OnTurnOnGenerator = delegate {  };

    [SerializeField] private TMP_Text tipText;
    
    [SerializeField] private UnityEvent OnFinishDishWashEvent = new UnityEvent();
    [SerializeField] private UnityEvent OnTurnOnGeneratorEvent = new UnityEvent();
    [SerializeField] private UnityEvent<Color> OnChangeAmbientLightEvent = new UnityEvent<Color>();

    private void Start()
    {
        ShowTip("Limpe os Pratos!");
    }

    private void OnEnable()
    {
        OnFinishDishWash += FinishDishWash;
        OnTurnOnGenerator += TurnOnGenerator;
        OnChangeAmbientLight += ChangeAmbientLight;
    }

    private void OnDisable()
    {
        OnFinishDishWash -= FinishDishWash;
        OnTurnOnGenerator -= TurnOnGenerator;
        OnChangeAmbientLight -= ChangeAmbientLight;
    }

    private void FinishDishWash()
    {
        OnFinishDishWashEvent?.Invoke();
    }

    private void TurnOnGenerator()
    {
        OnTurnOnGeneratorEvent?.Invoke();
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

    public void EndGame()
    {
        DOVirtual.DelayedCall(5f, () =>
        {
            FadeManager.FadeOut(1f, () =>
            {
                StartCoroutine(SceneManager.LoadScene("Main Menu"));
            });
        });
    }

    public void ShowTip(string tip)
    {
        tipText.text = tip;

        tipText.gameObject.SetActive(true);
        
        DOVirtual.DelayedCall(3f, () =>
        {
            tipText.text = "";
            tipText.gameObject.SetActive(false);
        });
    }
}
