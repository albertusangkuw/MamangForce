using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            SceneChanger.ChangeScene("Home");
            return;
        }
    }
}
