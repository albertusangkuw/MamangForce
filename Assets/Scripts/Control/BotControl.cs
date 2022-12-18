using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotControl : MonoBehaviour
{
    private PlayerController player;

    public GameObject botSensor;
    public float minWalk = 0;
    public float maxWalk = 2;

    public float maxCoolDownTime = 3;
    public float patrollRange = 10;
    public bool canWalk = true;
    public float fireRate = 1F;
    private float nextFire = 0.0F;
    private float climbFire = 0.0F;
    private GameObject sensorInstance;
    

//Target Direction: False->Left True->Right
    private bool targetDirection = false;
    private Vector2 intialPosition; 
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
        intialPosition = transform.position;
        targetDirection = (Random.value > 0.5f);
        sensorInstance = Instantiate(botSensor, gameObject.transform.position,Quaternion.Euler(new Vector3(0, 0, 0)));
        sensorInstance.transform.localScale = new Vector3(1 * patrollRange, 
                                                          0.5f,sensorInstance.transform.localScale.z);
        sensorInstance.GetComponent<BotSensor>().bot = gameObject;
    }

    private void calculateRangeWalk(){
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate(){
        if(canWalk){
            StartCoroutine(RandomWalk(Random.Range(1,maxCoolDownTime)));    
        }
    }

    IEnumerator  RandomWalk(float delay){
       canWalk = false;
       yield return new WaitForSecondsRealtime(delay);
       var sizeMove = Random.Range(minWalk,maxWalk);
       for (int i = 0; i < sizeMove; i++){
            if(targetDirection){
               player.Forward(); 
            }else{
               player.Backward();
            } 
       }
       targetDirection = !targetDirection; 
       canWalk = true;
    }

    public void ShootTarget(Vector2 positionTarget){
        if(Time.time < nextFire){
            return;
        }    
        nextFire = Time.time + fireRate;
        if(player.GetIsFacingForward() && positionTarget.x < transform.position.x){
            player.Backward();
        }else if(!player.GetIsFacingForward() && positionTarget.x > transform.position.x){
            player.Forward();
        }
        player.ShootMainGun();
    }

}