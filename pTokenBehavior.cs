using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pTokenBehavior : MonoBehaviour
{
    private bool isCollected = false;
    public GameObject pTokenCollectedParticuleSystem;

    void OnTriggerEnter2D(Collider2D col){
        
        Destroy(gameObject);
        Instantiate(pTokenCollectedParticuleSystem,this.transform.position,Quaternion.identity);
        if(!isCollected)
            FindObjectOfType<GameManager>().CollectPToken();
        isCollected = true;
        SoundPlayer.PlaySound("CoinCollect_" + Random.Range(1,4).ToString());
        
    }
    
}
