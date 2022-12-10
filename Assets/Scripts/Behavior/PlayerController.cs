using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType{
  Playable,
  Prisoner,
  Soldier,
  Boss,
}
public enum PlayerState {
  Idle,
  Walk,
  Jump,
  Shoot,
  Dead
}
public class PlayerController : MonoBehaviour
{
    public PlayerType type = PlayerType.Prisoner;
    public GameObject mainBullet;
    public GameObject specialBullet;
    public float moveSpeed = 30;
    public float jumpSpeed = 600;
    public Vector2 maxVelocity = new Vector2(9,5);
    
    public float specialGunAmmo = 4;
    public float specialGunBurst = 4;
    public float health = 100;
    
    private bool isOnGround = false;
    private bool isFacingForward = true;
    private bool isLadder;
    private bool isClimbing;
    private int currentState = (int) PlayerState.Idle;
    private Animator animationComponent;
    private Rigidbody2D rigidComponent;
    private float vertical;
    private float speed = 5f;
    private float defaultGravityScale;
    private float originalMoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rigidComponent = GetComponent<Rigidbody2D>();
        animationComponent = GetComponent<Animator>();
        originalMoveSpeed = moveSpeed;
        defaultGravityScale =  rigidComponent.gravityScale;
    }

    // Update is called once per frame
    void Update(){
      animationComponent.SetFloat ("Speed", Mathf.Abs(rigidComponent.velocity.x));
      Debug.Log(((PlayerState)currentState).ToString() + " ; " + isOnGround + ";" + rigidComponent.velocity.x + "u/s" ); 
      vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if (isClimbing){
            rigidComponent.gravityScale = 0f;
            rigidComponent.velocity = new Vector2(rigidComponent.velocity.x, vertical * speed);
        }
        else{
            rigidComponent.gravityScale =defaultGravityScale;
        }
    }

    public void Forward(){
      if(Mathf.Abs(rigidComponent.velocity.x) > maxVelocity.x){
        return;
      }
      currentState = (int) PlayerState.Walk;
      transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
      rigidComponent.AddForce(Vector2.right * moveSpeed);
      isFacingForward = true;
    }
    
    public void Backward(){
      if(Mathf.Abs(rigidComponent.velocity.x) > maxVelocity.x){
        return;
      }
      currentState = (int) PlayerState.Walk;
      transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
      rigidComponent.AddForce(Vector2.left * moveSpeed);
      isFacingForward = false;
    }
    
    public void Stop(){
      rigidComponent.velocity.Set(0,0);
    }
    
    public void Jump(){
      if(!isOnGround || rigidComponent.velocity[1] > maxVelocity.y){
        return;
      }
      rigidComponent.AddForce(Vector2.up * jumpSpeed);
      currentState  = (int) PlayerState.Jump;
      isOnGround = false;
    }

    public void Climb(float verticalAxisRaw){
      if (isLadder && Mathf.Abs(verticalAxisRaw) > 0f){
          isClimbing = true;
      }
    }

    public void ShootMainGun(){
      if(currentState == (int) PlayerState.Shoot){
        return;
      }
      currentState  = (int) PlayerState.Shoot;
      
      Quaternion rotation = Quaternion.Euler(new Vector3(0,0,0));
      Vector2 vDirection = Vector2.right;
      if(!isFacingForward){
        rotation = Quaternion.Euler(new Vector3(0,180,0));
        vDirection = Vector2.left;
      }
      Transform gunPoint = gameObject.transform.GetChild(1);
      GameObject bulletIntance = Instantiate(mainBullet, gunPoint.position, rotation);
      Bullet b = bulletIntance.GetComponent<Bullet>();
      b.whiteList = gameObject;
      b.direction = vDirection;
      currentState  = (int) PlayerState.Idle;
    }

    public void ShootSpecialGun(){
      if(specialGunAmmo <= 0 || specialGunBurst <= 0){
        return;
      }
      specialGunAmmo--;
      currentState  = (int) PlayerState.Shoot;
      
      Transform gunPoint = gameObject.transform.GetChild(1);

      Vector3 degreeRotation = new Vector3(0,0,0);
      Vector2 vDirection = Vector2.right;
      if(!isFacingForward){
        degreeRotation = new Vector3(0,180,0);
        vDirection = Vector2.left;
      }
      for (int i = 0; i < specialGunBurst; i++){
          Quaternion rotation =  Quaternion.Euler(degreeRotation.x, degreeRotation.y, Random.Range(-4f,4f));
          GameObject bulletIntance = Instantiate(specialBullet, gunPoint.position, rotation);
          Bullet b = bulletIntance.GetComponent<Bullet>();
          b.whiteList = gameObject;
          b.direction = vDirection;
      }
      currentState  = (int) PlayerState.Idle;
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if(other.CompareTag("Object")){
        currentState = (int) PlayerState.Idle;
        isOnGround = true;
      }
      if(other.CompareTag("Bullet")) {
        Bullet[] hitBullets = other.GetComponents<Bullet>();
        foreach (var b in hitBullets){
          if(!b.whiteList.Equals(gameObject)){
            health -= b.damage;    
          }
        }
        if(health <= 0){
          currentState = (int) PlayerState.Dead;
          
        }
      }
      if (other.CompareTag("Ladder")){
          isLadder = true;
      }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            rigidComponent.gravityScale = defaultGravityScale;
        }
    }

    public PlayerState GetCurrentState(){
       return (PlayerState) currentState;
    }
}
