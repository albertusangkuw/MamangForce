using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string label = "";
    public int mainGunPower = 100;
    public int specialGunPower = 100;

    public int specialGunAmmo = 4;

    public int moveSpeed = 10;

    public GameObject mainBullet;
    public GameObject specialBullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 direction = Vector3.zero;
      if(Input.GetKey(KeyCode.LeftArrow)){
        direction += Vector3.left;
      }
      if(Input.GetKey(KeyCode.RightArrow)){
        direction += Vector3.right;
      }
      if(Input.GetKey(KeyCode.DownArrow)){
        direction += Vector3.down;
      }
      if(Input.GetKey(KeyCode.UpArrow)){
        direction += Vector3.up;
      }

      if(direction != Vector3.zero){
        Vector3 translation = direction * Time.deltaTime * moveSpeed;
        transform.Translate(translation);  
        //Animate
      }

      if(Input.GetKeyDown(KeyCode.X)){
        ShootMain();
      }
    }

    void ShootMain(){
        Instantiate(mainBullet, transform.position, mainBullet.transform.rotation);
    }

}
