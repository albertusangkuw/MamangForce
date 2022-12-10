using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBarrel : Explosion
{
    // Start is called before the first frame update
    void Start()
    {
        colliderRange = gameObject.GetComponent<CircleCollider2D>();
        rigidComponent = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
      if(other.gameObject.CompareTag("Bullet")){
        StartCoroutine(WaitBeforeExplode(timeBeforeExplode));
      }
    }
    

}
