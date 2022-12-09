using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public Vector2 lastCheckPoint;
    public GameObject playerPrefab;
    public static int livesPlayer = 1;
    public Vector2 startLocation;
    private PlayerController[] bossEnemy;
    private PlayerController[] regularEnemy;
    private PlayerController[] prisoner;


    // Start is called before the first frame update
    void Start()
    {
        //GameObject[] FindGameObjectsWithTag(
        // Load All Object
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController currPlayer  = playerPrefab.GetComponent<PlayerController>();
        if(currPlayer.GetCurrentState().Equals(PlayerState.Dead)){
            livesPlayer--; 
           if(livesPlayer == 0){
            Debug.Log("Game Over");
                // Game Over;
           }else{

                // Transform Player to last position
           }
        }
        Debug.Log("Boss E:" + countDeadPlayer(bossEnemy) +
                    ", Reg E:" + countDeadPlayer(regularEnemy) +  
                    ", Prisoner:" + countDeadPlayer(prisoner));
    }

    private int countDeadPlayer(PlayerController[] players){
        int counter = 0;
        foreach (var p in players){
            if(p.GetCurrentState().Equals(PlayerState.Dead)){
                counter++;
            }
        }
        return counter;
    }

    void SummarySum(){
        //Tampilkan dan hitung score
    }
}
