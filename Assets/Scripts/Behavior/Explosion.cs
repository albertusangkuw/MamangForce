using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Bullet
{
    private CircleCollider2D  colliderRange;
    private bool isExploded = false;

    public float durationExplosion = 0.025f;
    public float radiusExplosion = 0.3f;
    private Rigidbody2D rigidComponent;
    // Start is called before the first frame update
    void Start()
    {
        initialDirection = transform.position;
        colliderRange = gameObject.GetComponent<CircleCollider2D>();
        rigidComponent = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
      transform.Translate(direction * Time.deltaTime * moveSpeed);
      if(Mathf.Abs(initialDirection.x)+range < Mathf.Abs(transform.position.x)){
          Explode();
      }
    }

    private void Explode(){
        colliderRange.radius = radiusExplosion;
        rigidComponent.velocity = Vector2.zero;
        isExploded =  true;
        Destroy(gameObject,durationExplosion);
    }
    private string triggerTarget  = "";
    private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.Equals(whiteList)) {
        return;
      }
      if(other.gameObject.CompareTag("Ladder")){
         return;
      }
      if(triggerTarget == ""){
        triggerTarget = other.gameObject.tag;
      }
      Explode();
    }
      
}
