using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlScheme : MonoBehaviour
{
    public KeyCode right = KeyCode.RightArrow;
    public KeyCode left = KeyCode.LeftArrow;
    public KeyCode jump = KeyCode.UpArrow;

    public KeyCode mainGun = KeyCode.X;

    public KeyCode specialGun = KeyCode.Z;

    private PlayerController player;
    
    public float fireRate = 0.15F;
    private float nextFire = 0.0F;
    // Start is called before the first frame update
    void Start()
    {
      player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(Input.GetKey(KeyCode.X) && Time.time > nextFire){
        nextFire = Time.time + fireRate;
        player.ShootMainGun();
      }
      if(Input.GetKeyDown(KeyCode.Z) && Time.time > nextFire){
        nextFire = Time.time + fireRate;
        player.ShootSpecialGun();
      }

      if(Input.GetKey(KeyCode.LeftArrow)){
        player.Backward();
      }
      if(Input.GetKey(KeyCode.RightArrow)){
        player.Forward();
      }
      
      if(Input.GetKey(KeyCode.UpArrow)){
        player.Climb(Input.GetAxisRaw("Vertical"));
        player.Jump();
      }

            
      if(Input.GetKeyUp(KeyCode.LeftArrow)){
        player.Stop();
      }
      if(Input.GetKeyUp(KeyCode.RightArrow)){
        player.Stop();
      }
    }
}
