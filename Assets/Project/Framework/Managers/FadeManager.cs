using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    private static FadeManager instance;

    [SerializeField] private CanvasGroup canvasGroup;
    
    [SerializeField] private GameObject fadeManager;
    [SerializeField] private Image backgroundImage;

    private Coroutine loadSceneCoroutine;
    private Coroutine fadeCoroutine;
    private Tween fadeTween;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        canvasGroup.blocksRaycasts = false;
        DontDestroyOnLoad(gameObject);
    }
    
    public static void FadeIn(float duration = 1f, Action OnEndFadeIn = null, bool useInPause = false)
    {
        if (!instance) return;

        OnEndFadeIn += () =>
        {
            //instance.fadeManager.SetActive(false);
        };
        
        instance.Fade(0, duration, OnEndFadeIn, useInPause);
    }

    public static void FadeOut(float duration = 1f, Action OnEndFadeOut = null)
    {
        if (!instance) return;

        instance.Fade(1, duration, OnEndFadeOut);
    }

    private void Fade(int value, float duration, Action OnEndFade, bool useInPause = false)
    {
        instance.canvasGroup.blocksRaycasts = true;

        fadeCoroutine = StartCoroutine(FadeAsync(value, duration, useInPause, OnEndFade));
    }

    private IEnumerator FadeAsync(int value, float duration, bool useInPause, Action OnEndFade)
    {
        canvasGroup.alpha = Mathf.Abs(1f - value);
        fadeTween = canvasGroup.DOFade(value, duration).SetUpdate(useInPause);

        yield return new WaitForSeconds(duration);

        instance.canvasGroup.blocksRaycasts = false;

        OnEndFade?.Invoke();
    }
}
