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
    public int moveSpeed = 10;
    public int jumpSpeed = 450;
    public int mainGunPower = 250;
    public int specialGunPower = 100;
    public int specialGunAmmo = 4;
    public int currentState = (int) PlayerState.Idle;
    public float gapGun = 0.7f;
    private bool isOnGround = false;
    private bool isFacingForward = true;
    public Animator animationComponent;
    public Rigidbody2D rigidComponent;
    public GameObject mainBullet;
    public GameObject specialBullet;

    // Start is called before the first frame update
    void Start()
    {
        rigidComponent = GetComponent<Rigidbody2D>();
        animationComponent = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     //animationComponent.SetInteger("CurrentState",currentState);
     animationComponent.SetFloat ("Speed", Mathf.Abs(rigidComponent.velocity.x));
		 //animationComponent.SetBool ("touchingGround", isOnGround);
     //Debug.Log(((PlayerState)currentState).ToString() + " ; " + isOnGround + ";" + rigidComponent.velocity + "u/s" ); 
    }
    public void Forward(){
      currentState = (int) PlayerState.Walk;
      transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
      rigidComponent.AddForce(Vector2.right * moveSpeed);
      isFacingForward = true;
    }
    public void Backward(){
      currentState = (int) PlayerState.Walk;
      transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
      rigidComponent.AddForce(Vector2.left * moveSpeed);
      isFacingForward = false;
    }

    public void Jump(){
      if(!isOnGround || rigidComponent.velocity[1] > 5){
        return;
      }
      rigidComponent.AddForce(Vector2.up * jumpSpeed);
      currentState  = (int) PlayerState.Jump;
      isOnGround = false;
    }

    public void ShootMainGun(){
      currentState  = (int) PlayerState.Shoot;
      
      Quaternion rotation = Quaternion.Euler(new Vector3(0,0,0));
      Vector2 gapDir = Vector2.right;
      if(!isFacingForward){
        rotation = Quaternion.Euler(new Vector3(0,180,0));
        gapDir = Vector2.left;
      }
      Vector2 position = transform.position;
      position += gapDir * gapGun;
      Instantiate(mainBullet, position, rotation);
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
      }
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.CompareTag("Object")) {
        currentState = (int) PlayerState.Idle;
        isOnGround = true;
      }

    }


}
