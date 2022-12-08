using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform trackingTarget;

    public int moveSpeed = 20;

    public float[] minPosition = new float[3]{-19, -9, 0};
    public float[] maxPosition = new float[3]{37,10, 0};
    // Start is called before the first frame update
    void Start()
    {
    }

    bool checkLimitPosition(float x, float y,float z){
      if(minPosition[0] >  x ||  x > maxPosition[0] ){
        Debug.Log("X" + minPosition[0] +  x + maxPosition[0]);
          return false;
      }
      Debug.Log(x + ";" + y );
      if(minPosition[1] >  y ||  y > maxPosition[1]){
        Debug.Log("Y"+ minPosition[1] +  y + maxPosition[1]);
          return false;
      }
      
      return true;
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
        Vector3 translation = direction * Time.deltaTime * moveSpeed;
        if(checkLimitPosition(transform.position.x + translation.x,
                              transform.position.y + translation.y,
                              transform.position.z + translation.z)){
          transform.Translate(translation);  
        }
      }
      

      if(trackingTarget != null){
        Vector3 newPosition =trackingTarget.position; 
        newPosition.z = transform.position.z;

        if(checkLimitPosition(newPosition.x,
                              newPosition.y,
                              newPosition.z)){
            transform.position = newPosition;
        }
      }
      
    }
}
