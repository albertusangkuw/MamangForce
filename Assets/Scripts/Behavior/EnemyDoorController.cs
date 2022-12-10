using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoorController : MonoBehaviour
{
    int hit = 0;
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        hit += 1;
        Debug.Log("Masuk hit" + hit);
        if (other.gameObject.CompareTag("Bullet") && hit! > 2)
        {
            GeneratedEnemies(other);
        }
    }
     public void GeneratedEnemies(Collider2D other)
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        int randEnemyId = Random.Range(0, enemies.Count);

        Debug.Log("Masuk peluru : " + hit);
        Vector2 position = transform.position;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        GameObject bulletIntance = Instantiate(enemies[randEnemyId], position, rotation);

        // generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);

        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
}
