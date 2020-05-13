using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandChanger : MonoBehaviour
{
    private bool isTriggeredOnce = false;
    [SerializeField] private bool isActive;
    [SerializeField] private string gameObjectName;


    
    void OnTriggerEnter2D(Collider2D col){
        if((col.gameObject.name == "Head" || col.gameObject.name == "Arm")&& !isTriggeredOnce){
            SpriteChange.HandChange(isActive,gameObjectName);
        }
    }
}
