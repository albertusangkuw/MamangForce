using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LivesValueHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         gameObject.GetComponent<TextMeshProUGUI>().text = "" + GamePlay.Instance.livesPlayer;
    }
}
