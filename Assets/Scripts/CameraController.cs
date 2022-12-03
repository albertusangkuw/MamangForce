using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform trackingTarget;

    public int moveSpeed = 10;

    public int[] minPosition = {};
    public int[] maxPosition = {};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 direction = Vector3.zero;
      if(Input.GetKey(KeyCode.A)){
        direction = Vector3.left;
      }else if(Input.GetKey(KeyCode.D)){
        direction = Vector3.right;
      }else if(Input.GetKey(KeyCode.S)){
        direction = Vector3.down;
      }else if(Input.GetKey(KeyCode.W)){
        direction = Vector3.up;
      }
      if(direction != Vector3.zero){
        transform.Translate(direction * Time.deltaTime * moveSpeed);
      }
      

      if(trackingTarget != null){
        transform.position = new Vector3(trackingTarget.position.x,trackingTarget.position.y, transform.position.z);
      }
      
    }
}
