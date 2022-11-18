using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static IEnumerator LoadScene(string sceneName, bool useFade = true)
    {
        var asyncOperation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        
        while (asyncOperation.progress < 0.9f)
        {
            yield return null;
        }

        if (useFade)
        {
            FadeManager.FadeIn();
        }
    }
}
