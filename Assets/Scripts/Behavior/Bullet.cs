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
      if(other.gameObject.Equals(whiteList)) {
        return;
      }
      if(other.gameObject.CompareTag("Ladder")){
         return;
      }
      if(other.gameObject.CompareTag("Bullet")){
         return;
      }
      Destroy(gameObject);
    }
}
