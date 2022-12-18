using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : Bullet
{
    public GameObject explosionPrefab;
    protected CircleCollider2D  colliderRange;

    private bool isExploded = false;

    protected string targetTag = "Bullet";
    public float timeBeforeExplode = 0f;
    public float durationExplosion = 0.025f;
    public float radiusExplosion = 0.74f;

    // Start is called before the first frame update
    void Start()
    {
        initialDirection = transform.position;
        colliderRange = gameObject.GetComponent<CircleCollider2D>();
        rigidComponent = gameObject.GetComponent<Rigidbody2D>();
        rigidComponent.AddForce(direction * moveSpeed * 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(initialDirection.x) + range < Mathf.Abs(transform.position.x))
        {
            Explode();
        }
    }


    protected void Explode(){

        colliderRange.radius = radiusExplosion;
        rigidComponent.velocity = Vector2.zero;
        isExploded = true;
        var explodeInstance = Instantiate(explosionPrefab, transform.position, Quaternion.Euler(new Vector3(0, 0, 0)));
        Destroy(explodeInstance,1);
        Destroy(gameObject, durationExplosion);
    }

    
    private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.Equals(whiteList)) {
        return;
      }
      if(other.gameObject.CompareTag("Ladder")){
         return;
      }
      StartCoroutine(WaitBeforeExplode(timeBeforeExplode));
    }
    
    protected IEnumerator WaitBeforeExplode(float time){

        yield return new WaitForSecondsRealtime(time);
        gameObject.tag = targetTag;
        Explode();
    }
}
