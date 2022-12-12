using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainF : MonoBehaviour, ExecuteMenu
{

    public void RunMenu(int index)
    {
        switch (index)
        {
            case 0:
                SceneChanger.ChangeScene("Level 1");
                break;
            case 1:
                // SceneChanger.ChangeScene("Options");
                break;
            case 2:
                SceneChanger.ChangeScene("Credit");
                break;
            case 3:
                Application.Quit();
                break;
        }
    }
}
