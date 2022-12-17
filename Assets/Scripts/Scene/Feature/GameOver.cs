using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(changeSceneToMainMenu());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.X)){
            SceneChanger.ChangeScene("Level 1");
            return;
        }
    }
    private IEnumerator changeSceneToMainMenu(){
        yield return new WaitForSecondsRealtime(3);
        SceneChanger.ChangeScene("Home");
    }
}
