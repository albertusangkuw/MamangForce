using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public GameObject selectOption;
    // Start is called before the first frame update
    void Start()
    {
        ChangeScene("Home");
    }

    // // Update is called once per frame
    // void Update()
    // {

    // }

    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
