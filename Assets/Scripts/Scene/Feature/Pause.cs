using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour, ExecuteMenu{
     public void RunMenu(int index){
          switch (index) 
            {
                case 0:
                    //Resume
                    SceneChanger.LoadPreviousScene();
                    break;
                case 1:
                    //Restart Level
                    SceneChanger.ChangeScene("Level 1");
                    break;
                case 2:
                    //Return Home
                    SceneChanger.ChangeScene("Home");
                    break;
            }
    }
}