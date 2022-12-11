// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class StartMenu : MonoBehaviour
// {
//     public Text play;
//     public Text credit;
//     public Text option;
//     // public Text exit;

//     private int numberOfOptions = 3;

//     private int selectedOption;

//     // Use this for initialization
//     void Start()
//     {
//         selectedOption = 1;
//         play.color = new Color32(255, 255, 255, 255);
//         credit.color = new Color32(0, 0, 0, 255);
//         option.color = new Color32(0, 0, 0, 255);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.DownArrow) /*|| Controller input*/)
//         { //Input telling it to go up or down.
//             selectedOption += 1;
//             if (selectedOption > numberOfOptions) //If at end of list go back to top
//             {
//                 selectedOption = 1;
//             }

//             play.color = new Color32(0, 0, 0, 255); //Make sure all others will be black (or do any visual you want to use to indicate this)
//             credit.color = new Color32(0, 0, 0, 255);
//             option.color = new Color32(0, 0, 0, 255);

//             switch (selectedOption) //Set the visual indicator for which option you are on.
//             {
//                 case 1:
//                     play.color = new Color32(255, 255, 255, 255);
//                     break;
//                 case 2:
//                     credit.color = new Color32(255, 255, 255, 255);
//                     break;
//                 case 3:
//                     option.color = new Color32(255, 255, 255, 255);
//                     break;
//             }
//         }

//         if (Input.GetKeyDown(KeyCode.UpArrow) /*|| Controller input*/)
//         { //Input telling it to go up or down.
//             selectedOption -= 1;
//             if (selectedOption < 1) //If at end of list go back to top
//             {
//                 selectedOption = numberOfOptions;
//             }

//             play.color = new Color32(0, 0, 0, 255); //Make sure all others will be black (or do any visual you want to use to indicate this)
//             credit.color = new Color32(0, 0, 0, 255);
//             option.color = new Color32(0, 0, 0, 255);

//             switch (selectedOption) //Set the visual indicator for which option you are on.
//             {
//                 case 1:
//                     play.color = new Color32(255, 255, 255, 255);
//                     break;
//                 case 2:
//                     credit.color = new Color32(255, 255, 255, 255);
//                     break;
//                 case 3:
//                     option.color = new Color32(255, 255, 255, 255);
//                     break;
//             }
//         }

//         // if (Input.GetKeyDown(KeyCode.Return)){
//         //     FindSceneObjectsOfType<ChangeScene>("asdf");
//         // }

//         // if (Input.GetKeyDown(KeyCode.Return) ||  Input.GetKeyDown("joystick button 0")){
//         //     Debug.Log("Picked: " + selectedOption); //For testing as the switch statment does nothing right now.

//         //     switch (selectedOption) //Set the visual indicator for which option you are on.
//         //     {
//         //         case 1:
//         //             /*Do option one*/
//         //             break;
//         //         case 2:
//         //             /*Do option two*/
//         //             break;
//         //         case 3:
//         //             /*Do option two*/
//         //             break;
//         //     }
//         // }
//     }
// }
