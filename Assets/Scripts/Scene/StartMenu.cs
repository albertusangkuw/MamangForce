using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    
    // public Text exit;

    public GameObject[] menuList;

    private int currentSelected ;    
    private int selectedOption;

    // Use this for initialization
    void Start()
    {
        selectedOption = 0;
        currentSelected = 0;
        
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
            SceneChanger.ChangeScene("Level 4");
        }
        MoveBackground(selectedOption);
    }
    void SelectedOption(int selectedOption){
        switch (selectedOption) 
            {
                case 1:
                    
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
            }
    }
    void MoveBackground(int idx){
        transform.position = menuList[idx].transform.position;
    }
}
