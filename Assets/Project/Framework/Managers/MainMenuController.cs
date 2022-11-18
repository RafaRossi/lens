using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string SceneName = "Gameplay";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClickToPlay();
        }
    }

    public void ClickToPlay()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        FadeManager.FadeOut(1f, () =>
        {
            StartCoroutine(SceneManager.LoadScene(SceneName));
        });
    }
}
