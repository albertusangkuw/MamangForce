using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class GamePlay : MonoBehaviour
{
    //Ref Point for other script
    public static GamePlay Instance { get; private set; }

    public static Dictionary<string, int> level = new Dictionary<string, int>();
    // Shared Variabel
    public Vector2 lastCheckPoint;
    public GameObject playerPrefab;

    public GameObject pausePrefab;
    public GameObject gameOverPrefab;
    public GameObject winPrefab;
    public GameObject failedPrefab;

    public int livesPlayer = 1;
    public bool isGameFinished = false;

    public int currentLevel = 1;

    public int maxLevel = 3;

    private CinemachineVirtualCamera vCam;
    private List<PlayerController> bossEnemyInst;

    private GameObject currPlayer;
    private int killedBoss;
    private int killedSoldier;
    private int relasedPrisoner;

    private GameObject pauseInstance;
    // Always use empty Instance
    private void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        vCam = gameObject.GetComponent<CinemachineVirtualCamera>();
        respawn(lastCheckPoint, Quaternion.Euler(new Vector3(0, 0, 0)));
        StartCoroutine(changeTargetCamera(0, currPlayer));
    }

    // Update is called once per frame
    void Update()
    {
        if(currPlayer == null){
            return;
        }
        PlayerController curr = currPlayer.GetComponent<PlayerController>();
        
        if(pauseInstance == null && curr.isPause){
            Pause();
            return;    
        }else if(pauseInstance != null && !curr.isPause ){
            Destroy(pauseInstance);
        }
        
        
        if (curr.GetIsDead())
        {
            livesPlayer--;
            if (livesPlayer > 0){
               currPlayer=null;
               ShowMissionFailed();
            }
            else{
                // Game Over;
                Debug.Log("Game Over");
                SceneChanger.ChangeScene("GameOver");
                Destroy(gameObject);
            }
        }
        
        Debug.Log("Boss E:" + killedBoss +
                    ", Reg E:" + killedSoldier +
                    ", Prisoner:" + relasedPrisoner);

    }
    public IEnumerator changeTargetCamera(float delay, GameObject p)
    {
        yield return new WaitForSecondsRealtime(delay);
        vCam.m_Follow = p.transform;
    }

    void LateUpdate()
    {
        if (isGameFinished){
           StartCoroutine(SummarySum());
           isGameFinished = false;
        }
    }

    private void respawn(Vector2 position, Quaternion rotation)
    {
        var newPlayer = Instantiate(playerPrefab, position, rotation);
        currPlayer = newPlayer;
        var curr = currPlayer.GetComponent<PlayerController>();
        curr.type = PlayerType.Playable;
    }

    public void UpdatePlayerState(PlayerController player)
    {
        
        if(currPlayer == null){
            return;
        }
        Debug.Log("Type Player:" + player.type);
        if (player.type.Equals(PlayerType.Boss))
        {
            killedBoss++;
        }
        if (player.type.Equals(PlayerType.Prisoner))
        {
            relasedPrisoner++;
            livesPlayer++;
        }
        if (player.type.Equals(PlayerType.Soldier))
        {
            killedSoldier++;
        }
    }

    void Pause(){
        var scale = 2.2f;
        var currPos = gameObject.transform.position;
        pauseInstance = Instantiate(pausePrefab,new Vector2(currPos.x, currPos.y),Quaternion.Euler(new Vector3(0, 0, 0)));
        pauseInstance.transform.localScale = new Vector3(pausePrefab.transform.localScale.x * scale, 
                                                       pausePrefab.transform.localScale.y  * scale, 
                                                       pausePrefab.transform.localScale.z  * scale);
    }

    public void Unpause(){
        PlayerController curr = currPlayer.GetComponent<PlayerController>();
        curr.isPause = false;
        Destroy(pauseInstance);
    }

    protected void ShowMissionFailed(){
        var scale = 2.2f;
        var currPos = gameObject.transform.position;
        var failedInstance = Instantiate(failedPrefab,new Vector2(currPos.x, currPos.y),Quaternion.Euler(new Vector3(0, 0, 0)));
        failedInstance.transform.localScale = new Vector3(failedPrefab.transform.localScale.x * scale, 
                                                       failedPrefab.transform.localScale.y  * scale, 
                                                       failedPrefab.transform.localScale.z  * scale);
        Destroy(failedInstance,2);
        respawn(lastCheckPoint, Quaternion.Euler(new Vector3(0, 0, 0)));
        StartCoroutine(changeTargetCamera(2.5f, currPlayer));
    }

    protected void ShowScoreMissionSuccess(int totalScore){
        var scale = 0.05f;
        var currPos = gameObject.transform.position;
        Debug.Log("Score sekarang: " + totalScore );
        var winInstance = Instantiate(winPrefab,new Vector2(currPos.x, currPos.y),Quaternion.Euler(new Vector3(0, 0, 0)));
        winInstance.transform.localScale = new Vector3(winPrefab.transform.localScale.x * scale, 
                                                       winPrefab.transform.localScale.y  * scale, 
                                                       winPrefab.transform.localScale.z  * scale);
        var scoreValue = winInstance.transform.Find("ScoreValue");
        if(scoreValue != null){
            scoreValue.GetComponent<TextMeshProUGUI>().text = ": " + totalScore;
        }else{
            Debug.Log("Value Label Not Found");
        }
    }
    protected IEnumerator SummarySum()
    {
        yield return new WaitForSecondsRealtime(1);
        var curr = currPlayer.GetComponent<PlayerController>();
        curr.type = PlayerType.UnLabeled;
        //Hitung score
        var  totalScore = getCurrentScore();
        //Tampilkan Score
        ShowScoreMissionSuccess(totalScore);
        
        yield return new WaitForSecondsRealtime(4);
        if(currentLevel < maxLevel){
            currentLevel++;
            SceneChanger.ChangeScene("Level " + currentLevel);
            Destroy(gameObject);
        }else{
            SceneChanger.ChangeScene("GameOver");
        }
    }

    public int getCurrentScore(){
        int poinBoss = 15;
        int poinPrisoner = 10;
        int poinSoldier = 5;
        var totalScore = poinBoss * killedBoss + poinPrisoner * relasedPrisoner + poinSoldier * killedSoldier;
        return totalScore;
    }
    void OnDestory()
    {
        //Clean Gameplay Instance
        if (Instance == this)
        {
            Instance = null;
        }
    }
}

