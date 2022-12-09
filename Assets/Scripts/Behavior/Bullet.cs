using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int moveSpeed = 25;
    public Vector2 direction = Vector2.right;

    public float range = 12;
    public GameObject whiteList;
    protected Vector2 initialDirection;
    // Start is called before the first frame update
    void Start()
    {
        initialDirection = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime * moveSpeed);
        if (Mathf.Abs(initialDirection.x) + range < Mathf.Abs(transform.position.x))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(whiteList))
        {
            return;
        }
        if (other.gameObject.CompareTag("Ladder"))
        {
            return;
        }
        // if(other.gameObject.CompareTag("Object")){
        //   Destroy(other.gameObject);
        // }
        Destroy(gameObject);
    }
}
