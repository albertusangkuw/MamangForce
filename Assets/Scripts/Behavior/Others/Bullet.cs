using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int moveSpeed = 25;
    public Vector2 direction = Vector2.zero;

    public int damage = 100;
    public float range = 12;
    public GameObject whiteList;

    public string[] targetList = {"Object", "SpaceLimit", "EnemyDoor"};
    protected Vector2 initialDirection;
    protected Rigidbody2D rigidComponent;
    // Start is called before the first frame update
    void Start()
    {
        initialDirection = transform.position;
        rigidComponent = GetComponent<Rigidbody2D>();
        rigidComponent.AddForce(direction * moveSpeed * 10);
    }

    // Update is called once per frame
    void Update()
    {

      
      //transform.Translate(direction * Time.deltaTime * moveSpeed);
      if(Mathf.Abs(initialDirection.x)+range < Mathf.Abs(transform.position.x)){
          Destroy(gameObject);
      }
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.CompareTag("Untagged")){
        return;
      }
      if(other.gameObject.Equals(whiteList)) {
        return;
      }
      foreach (var item in targetList){
       if(other.gameObject.CompareTag(item)){
          Destroy(gameObject);   
          return;
       } 
      }
      
      

    }
}
