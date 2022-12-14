using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private static SceneController sc;

    // Start is called before the first frame update
    void Start()
    {
        sc = new SceneController();
        ChangeScene("Home");
    }


    public static void ChangeScene(string sceneName)
    {
        // sc.LoadScene(sceneName);
        SceneManager.LoadScene(sceneName);
    }

    public static void LoadPreviousScene()
    {
        sc.LoadPreviousScene();
    }
    public static IEnumerator ChangeSceneWait(string sceneName, float time)
    {
        yield return new WaitForSecondsRealtime(time);
        ChangeScene(sceneName);
    }

    public static IEnumerator BackSceneWait(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        LoadPreviousScene();
    }
}
