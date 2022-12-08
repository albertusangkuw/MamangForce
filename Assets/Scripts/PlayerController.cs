using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState {
  Idle,
  Walk,
  Jump,
  Shoot,
  Dead
}
public class PlayerController : MonoBehaviour
{
    public int moveSpeed = 30;

    public Vector2 maxVelocity = new Vector2(9,5);
    public int jumpSpeed = 600;
    public int mainGunPower = 250;
    public int specialGunPower = 100;
    public int specialGunAmmo = 4;
    public int currentState = (int) PlayerState.Idle;
    public int health = 100;
    public float gapGun = 0.7f;
    private bool isOnGround = false;
    private bool isFacingForward = true;
    
    public Animator animationComponent;
    public Rigidbody2D rigidComponent;
    public GameObject mainBullet;
    public GameObject specialBullet;

    private int originalMoveSpeed ;
    // Start is called before the first frame update
    void Start()
    {
        rigidComponent = GetComponent<Rigidbody2D>();
        animationComponent = GetComponent<Animator>();
        originalMoveSpeed = moveSpeed;
        //colliderSize = GetComponent<CapsuleCollider2D>().size;
        
    }

    // Update is called once per frame
    void Update()
    {
     //animationComponent.SetInteger("CurrentState",currentState);
     animationComponent.SetFloat ("Speed", Mathf.Abs(rigidComponent.velocity.x));
		 //animationComponent.SetBool ("touchingGround", isOnGround);
     Debug.Log(((PlayerState)currentState).ToString() + " ; " + isOnGround + ";" + rigidComponent.velocity.x + "u/s" ); 
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

    public void ShootMainGun(){
      if(currentState == (int) PlayerState.Shoot){
        return;
      }
      currentState  = (int) PlayerState.Shoot;
      
      Quaternion rotation = Quaternion.Euler(new Vector3(0,0,0));
      Vector2 gapDir = Vector2.right;
      if(!isFacingForward){
        rotation = Quaternion.Euler(new Vector3(0,180,0));
        gapDir = Vector2.left;
      }
      Vector2 position = transform.position;
      position += gapDir * gapGun * Time.deltaTime ;
      GameObject bulletIntance  = Instantiate(mainBullet, position, rotation);
      Bullet b = bulletIntance.GetComponent<Bullet>();
      b.whiteList = gameObject;
      currentState  = (int) PlayerState.Idle;
    }

    public void ShootSpecialGun(){
      currentState  = (int) PlayerState.Shoot;
      Vector2 v = transform.position;
      int burst = 5;
      Quaternion rotation = Quaternion.Euler(new Vector3(0,0,0));
      Vector2 gapDir = Vector2.right;
      if(!isFacingForward){
        rotation = Quaternion.Euler(new Vector3(0,180,0));
        gapDir = Vector2.left;
      }
      for (int i = 0; i < burst; i++){
        Vector2 margin = Vector2.up;
        if(i > burst/2){
          margin = Vector2.down;
        }
        v += margin * (i+1)/10;
        v += gapDir * gapGun;
        Instantiate(mainBullet, v, rotation);
        currentState  = (int) PlayerState.Idle;
      }
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.CompareTag("Object")) {
        currentState = (int) PlayerState.Idle;
        isOnGround = true;
      }
      if(other.gameObject.CompareTag("Bullet")) {
        currentState = (int) PlayerState.Dead;
      }

    }


}
