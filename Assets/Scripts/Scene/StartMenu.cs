using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ExecuteMenu
{
    void RunMenu(int index);
}
public class StartMenu : MonoBehaviour
{
    
    // public Text exit;

    public GameObject[] menuList;
    public ExecuteMenu menuExec;
    private int currentSelected ;    
    private int selectedOption;

    // Use this for initialization
    void Start()
    {
        selectedOption = 0;
        currentSelected = 0;
        menuExec = GetComponent<ExecuteMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)){ 
            selectedOption++;
            if (selectedOption >= menuList.Length){
                selectedOption = 0;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)){ 
            selectedOption--;
            if (selectedOption < 0){
                selectedOption = menuList.Length-1;
            }
            
        }
        if(Input.GetKeyDown(KeyCode.X)){
           menuExec.RunMenu(selectedOption);
        }
        MoveBackground(selectedOption);
    }
    void MoveBackground(int idx){
        transform.position = menuList[idx].transform.position;
    }
}
