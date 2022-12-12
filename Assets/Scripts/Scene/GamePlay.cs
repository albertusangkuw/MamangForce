using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class GamePlay : MonoBehaviour
{
    //Ref Point for other script
    public static GamePlay Instance { get; private set; }
    
    public static Dictionary<string, int> level = new Dictionary<string, int>();
    // Shared Variabel
    public Vector2 lastCheckPoint;
    public GameObject playerPrefab;
    public int livesPlayer = 1;
    public bool isGameFinished = false;

    public int currentLevel = 1;
    
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
           if(livesPlayer > 0){
            // Transform Player to last position and facing forward
            respawn(lastCheckPoint,Quaternion.Euler(new Vector3(0,0,0)));
           }else{
             // Game Over;
             Debug.Log("Game Over");
            // SceneChanger.ChangeScene("Game Over");
            Destroy(gameObject);
           }
        }
        Debug.Log("Boss E:" + killedBoss +
                    ", Reg E:" + killedSoldier +  
                    ", Prisoner:" + relasedPrisoner);

    }

    void LateUpdate(){
        if(isGameFinished){
            Debug.Log("Game is finish !!@");
            SummarySum();
        }
    }
    
    private void respawn(Vector2 position, Quaternion rotation){
    //   SceneChanger.ChangeScene("Mission Failed");  
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
            livesPlayer++;
        }
        if(player.type.Equals(PlayerType.Soldier)){
            killedSoldier++;
        }
    }  

    void SummarySum(){
        //Tampilkan dan hitung score
        SceneChanger.ChangeScene("Level "+ currentLevel);
        Destroy(gameObject);
    }
    void OnDestory(){
        //Clean Gameplay Instance
        if(Instance == this){
            Instance = null;
        }
    }
}
