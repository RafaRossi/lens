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
            Debug.Log(asyncOperation.progress);
            yield return null;
        }
        
        Debug.Log("Finish");
        
        if (useFade)
        {
            FadeManager.FadeIn();
        }
    }
}
