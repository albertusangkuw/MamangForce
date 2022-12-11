using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CheckPointType{
    Normal,
    Final
}
public class PlayerPoint : MonoBehaviour
{
    public CheckPointType type = CheckPointType.Normal;
    private bool isAlreadyPassed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player") &&  !isAlreadyPassed){
           var p  = other.gameObject.GetComponent<PlayerController>();
           if(p.type.Equals(PlayerType.Playable)){
                GamePlay.Instance.lastCheckPoint = transform.position;
                isAlreadyPassed = true;
                if(type.Equals(CheckPointType.Final)){
                    GamePlay.Instance.isGameFinished = true;
                }
           }
        }
    }
}
