using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protagonist : MonoBehaviour
{
    private PlayerController target;
    void  Start(){
        target = GetComponent<PlayerController>();
    }
    void LateUpdate(){
        // Get Killed
        if(target.GetIsDead()){
            GamePlay.Instance.UpdatePlayerState(target);
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        // Save Prisoner
        if(other.CompareTag("Player")){
            if(other.GetComponent<PlayerController>().type.Equals(PlayerType.Prisoner)){
                GamePlay.Instance.UpdatePlayerState(target);
            }
        }

        //Get Loot Box

    }


}
