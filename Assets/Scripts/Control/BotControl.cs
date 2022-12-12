using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotControl : MonoBehaviour
{
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            var anotherPlayer = other.GetComponent<PlayerController>();
            if (anotherPlayer.type.Equals(PlayerType.Playable))
            {
                player.ShootMainGun();
            }

        }
    }
}