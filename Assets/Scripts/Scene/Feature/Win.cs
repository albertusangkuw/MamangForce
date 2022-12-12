using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour, ExecuteMenu
{
    void Start()
    {
        int num = GamePlay.level.GetValueOrDefault("Level");
        int boss = GamePlay.level.GetValueOrDefault("Boss");
        int soldier = GamePlay.level.GetValueOrDefault("Soldier");
        int prisioner = GamePlay.level.GetValueOrDefault("Prisioner");


    }
    public void RunMenu(int index)
    {

    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.X))
        {
            SceneChanger.ChangeScene("Home");
            return;
        }
    }
}
