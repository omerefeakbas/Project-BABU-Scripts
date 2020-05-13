using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBreaker : MonoBehaviour
{
    private bool isTimeScaleChanged = false;
    [SerializeField] float changeAmount;
    private Animator textAnimator;

    void Start(){
        textAnimator = GameObject.Find("TimeScaleChangedText").GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D col){
        col.gameObject.GetComponentInParent<CharacterMovement>().isMovingForward = true;
        if((col.gameObject.name == "Head" || col.gameObject.name == "Arm")&&!isTimeScaleChanged){
            Time.timeScale += ((Time.timeScale + changeAmount)/Time.timeScale)-1;
            
            textAnimator.SetTrigger("ShowText");
            isTimeScaleChanged = true;
        }
    }
}
