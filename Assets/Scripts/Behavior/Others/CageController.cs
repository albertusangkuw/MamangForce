using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageController : MonoBehaviour
{

    int currHit = 0;
    int maxHitDestroyCage = 10;
    public List<GameObject> player = new List<GameObject>();
    public List<GameObject> playerToSpawn;
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
        if (other.gameObject.CompareTag("Bullet"))
        {
            currHit += 1;
            Debug.Log("Masuk currHit" + currHit);
            if (currHit >= maxHitDestroyCage)
            {
                Destroy(gameObject);
                GeneratedPlayer(other);
            }
        }
    }

    public void GeneratedPlayer(Collider2D other)
    {
        int randPlayerId = Random.Range(0, player.Count);
        // Debug.Log("Posisi pintu :" + GameObject.FindGameObjectWithTag("EnemyDoor").transform.position);
        Vector2 position = transform.position;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        GameObject playerIntance = Instantiate(player[randPlayerId], position, rotation);
        playerIntance.GetComponent<PlayerController>().type = PlayerType.Prisoner;

        // generatedEnemies.Add(enemies[randEnemyId].enemyPrefab);

        // enemiesToSpawn.Clear();
        // enemiesToSpawn = generatedEnemies;
    }

}
