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

    public PlayerController player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(Input.GetKeyDown(KeyCode.X)){
        player.ShootMainGun();
      }
      if(Input.GetKeyDown(KeyCode.Z)){
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
