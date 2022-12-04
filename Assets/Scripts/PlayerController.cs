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
    public int jumpSpeed = 500;
    public int mainGunPower = 100;
    public int specialGunPower = 100;
    public int specialGunAmmo = 4;
    public int currentState = (int) PlayerState.Idle;

    private bool isOnGround = false;
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
     Debug.Log(((PlayerState)currentState).ToString() + " ; " + isOnGround); 
    }
    public void Forward(){
      currentState = (int) PlayerState.Walk;
      if(transform.rotation.y != 0){
        transform.rotation.Set(transform.rotation.x,0,transform.rotation.z, transform.rotation.w);
      }
      rigidComponent.AddForce(Vector2.right * moveSpeed) ;
    }
    public void Backward(){
      currentState = (int) PlayerState.Walk;
      if(transform.rotation.y != 180){
        transform.rotation.Set(transform.rotation.x,180,transform.rotation.z, transform.rotation.w);
      }
      rigidComponent.AddForce(Vector2.left * moveSpeed);
    }

    public void Jump(){
      if(!isOnGround){
        return;
      }
      rigidComponent.AddForce(Vector2.up * jumpSpeed);
      currentState  = (int) PlayerState.Jump;
      isOnGround = false;
    }

    public void ShootMainGun(){
      currentState  = (int) PlayerState.Shoot;
      Instantiate(mainBullet, transform.position, mainBullet.transform.rotation);
    }

    public void ShootSpecialGun(){
      currentState  = (int) PlayerState.Shoot;
      Vector2 v = transform.position;
      int burst = 5;
      for (int i = 0; i < burst; i++)
      {
        v += Vector2.up * i;
        Instantiate(mainBullet, v, mainBullet.transform.rotation);
      }
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.CompareTag("Ground")) {
        currentState = (int) PlayerState.Idle;
        isOnGround = true;
      }

    }


}
