using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public Vector2 parallaxEffectMultiplier;

    private Vector3 lastPosition;


    public GameObject target;
    private float textureUnitSizeX;
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = target.transform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target == null){
            return;
        }
        Vector3 deltaMovement = target.transform.position - lastPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x,
                                            deltaMovement.y * parallaxEffectMultiplier.y);
        lastPosition = target.transform.position;
        if(Mathf.Abs(target.transform.position.x - transform.position.x) >= textureUnitSizeX){
            float offsetPositionX = (target.transform.position.x - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3(target.transform.position.x+ offsetPositionX, target.transform.position.y);
        }


        //transform.position = target.transform.position;
        
    }
}
