using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Vector2 parallaxEffectMultiplier;
    public GameObject target;

    private Vector2 lastPosition;

    private Vector2 sizeSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = target.transform.position;
        sizeSprite = GetComponent<SpriteRenderer>().bounds.size;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target == null){
            return;
        }
        float temp = (target.transform.position.x * (1 - parallaxEffectMultiplier.x));
        float dist = (target.transform.position.x * parallaxEffectMultiplier.x);

        transform.position = new Vector3(lastPosition.x + dist, 
                                         target.transform.position.y, 
                                         transform.position.z);
        if(temp > lastPosition.x + sizeSprite.x){
            lastPosition += sizeSprite;
        }else if(temp < lastPosition.x - sizeSprite.x){
            lastPosition -= sizeSprite;
        }
    }
}
