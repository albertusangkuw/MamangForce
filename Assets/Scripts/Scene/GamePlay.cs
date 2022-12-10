using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class GamePlay : MonoBehaviour
{
    //Ref Point for other script
    public static GamePlay Instance { get; private set; }
    // Shared Variabel
    public Vector2 lastCheckPoint;
    public GameObject playerPrefab;
    public int livesPlayer = 1;
    public bool isGameFinished = false;

    private CinemachineVirtualCamera vCam;
    private List<PlayerController> bossEnemyInst;
    
    private GameObject currPlayer;
    private int killedBoss;
    private int killedSoldier;
    private int relasedPrisoner;

    // Always use empty Instance
   private void Awake(){
        
        if(Instance != null && Instance != this){ 
            Destroy(this); 
        } 
        else{ 
            Instance = this; 
        } 
    }
    // Start is called before the first frame update
    void Start()
    {
        vCam =  gameObject.GetComponent<CinemachineVirtualCamera>();
        respawn(lastCheckPoint,Quaternion.Euler(new Vector3(0,0,0)));
    }

    // Update is called once per frame
    void Update(){
        if(currPlayer.GetComponent<PlayerController>().GetCurrentState().Equals(PlayerState.Dead)){
           livesPlayer--; 
           Destroy(currPlayer);
           if(livesPlayer > 0){
            // Transform Player to last position and facing forward
            respawn(lastCheckPoint,Quaternion.Euler(new Vector3(0,0,0)));
           }else{
             // Game Over;
             Debug.Log("Game Over");
           }
        }
        Debug.Log("Boss E:" + killedBoss +
                    ", Reg E:" + killedSoldier +  
                    ", Prisoner:" + relasedPrisoner);

    }

    void LateUpdate(){
        if(isGameFinished){
            //
            Debug.Log("Game is finish !!@");
        }
    }

    private void respawn(Vector2 position, Quaternion rotation){
      var newPlayer = Instantiate(playerPrefab,position,rotation);
      vCam.m_Follow = newPlayer.transform;
      currPlayer = newPlayer;
    }
  
    public void UpdatePlayerState(PlayerController player){
        if(player.type.Equals(PlayerType.Boss)){
            killedBoss++;
        }
        if(player.type.Equals(PlayerType.Prisoner)){
            relasedPrisoner++;    
        }
        if(player.type.Equals(PlayerType.Soldier)){
            killedSoldier++;
        }
    }  

    void SummarySum(){
        //myCinemachine = GetComponent<CinemachineVirtualCamera>();
        //Tampilkan dan hitung score
    }
    void OnDestory(){
        //Clean Gameplay Instance
        if(Instance == this){
            Instance = null;
        }
    }
}
