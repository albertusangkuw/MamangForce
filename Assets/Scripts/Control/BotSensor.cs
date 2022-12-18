using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotSensor : MonoBehaviour
{
    public GameObject bot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void LateUpdate(){
        if(bot == null){
            Destroy(gameObject);
            return;
        }
        transform.position = bot.transform.position;
    }
     private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player")){
           StartCoroutine(TagTarget(other));
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){ 
            StartCoroutine(TagTarget(other));
        }
    }

    private void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Player")){ 
            StartCoroutine(TagTarget(other));
        }
    }

    private IEnumerator TagTarget(Collider2D other){
        if(bot == null){
            Destroy(gameObject);
            yield return new WaitForSecondsRealtime(0);
        }else{
            yield return new WaitForSecondsRealtime(1.5f);
            var anotherPlayer = other.GetComponent<PlayerController>();
            if (anotherPlayer.type.Equals(PlayerType.Playable)){   
                var botControl = bot.GetComponent<BotControl>();
                botControl.ShootTarget(other.transform.position);
            }
        }
    }
}
