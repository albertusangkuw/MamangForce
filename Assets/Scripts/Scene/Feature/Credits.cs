using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits  : MonoBehaviour, ExecuteMenu {
     public void RunMenu(int index){
          switch (index) 
            {
                case 0:
                    SceneChanger.ChangeScene("Home");
                    break;
            }
    }
}