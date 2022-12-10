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
        // currHit += 1;
        // if (other.gameObject.CompareTag("Bullet") && currHit > 2)
        // {
        //     Destroy(gameObject);
        // }

        currHit += 1;
        Debug.Log("Masuk currHit" + currHit);
        if (other.gameObject.CompareTag("Bullet"))
        {

            if (currHit >= 10)
            {
                Destroy(gameObject);
            }
            else if (currHit % 2 == 0)
            {
                GeneratedEnemies(other);
            }
        }
    }

    public void GeneratedEnemies(Collider2D other)
    {
        enemiesToSpawn.Clear();

        enemiesToSpawn = new List<GameObject>();
        int randEnemyId = Random.Range(0, enemies.Count);

        // Debug.Log("Masuk peluru : " + currHit);
        // Debug.Log("Posisi pintu :" + GameObject.FindGameObjectWithTag("EnemyDoor").transform.position);
        // Vector2 position = transform.position;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        GameObject bulletIntance = Instantiate(enemies[randEnemyId], new Vector3(5.40f, 12.97f, 0), rotation);

        // generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);

        // enemiesToSpawn.Clear();
        // enemiesToSpawn = generatedEnemies;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        hit += 1;
        if (other.gameObject.CompareTag("Bullet") && hit! > 2)
        {
            GeneratedEnemies(other);
        }
    }
     public void GeneratedEnemies(Collider2D other)
    {
        List<GameObject> generatedEnemies = new List<GameObject>();
        int randEnemyId = Random.Range(0, enemies.Count);

        Vector2 position = transform.position;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        GameObject bulletIntance = Instantiate(enemies[randEnemyId], position, rotation);

        // generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);

        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }
}
