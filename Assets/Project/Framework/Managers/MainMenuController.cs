using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private string SceneName = "Gameplay";
    
    public void ClickToPlay()
    {
        FadeManager.FadeOut(1f, () =>
        {
            StartCoroutine(SceneManager.LoadScene(SceneName));
        });
    }
}
