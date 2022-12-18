using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confirmation : MonoBehaviour, ExecuteMenu
{
    
    public void RunMenu(int index){
          switch (index) 
            {
                case 0:
                    // Yes
                    Application.Quit();
                    break;
                case 1:
                    // No
                    SceneChanger.ChangeScene("Home");
                    break;
            }
    }
}
