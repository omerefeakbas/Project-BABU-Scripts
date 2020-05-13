using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToggle : MonoBehaviour
{
    [SerializeField] private GameObject arm;
    [SerializeField] private GameObject head;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 headTarget;
    [SerializeField] private Vector3 armTarget;
    [SerializeField] private Vector3 headIddle;
    [SerializeField] private Vector3 armIddle;

    public bool release = false;
    public bool isHanged = false;

    // Update is called once per frame
    void Update()
    {
        if(!isHanged){
            if(Input.GetMouseButton(0)){
                arm.transform.position = Vector3.MoveTowards(arm.transform.position,new Vector3(arm.transform.position.x,head.transform.position.y,0),speed);
            }
            else if(release){
                arm.transform.position = Vector3.MoveTowards(arm.transform.position,new Vector3(arm.transform.position.x,head.transform.position.y+5,0),speed);
                release = false;
            }
            else{
                arm.transform.position = Vector3.MoveTowards(arm.transform.position,new Vector3(arm.transform.position.x,head.transform.position.y+5,0),speed);
            }  
        }
        else{
            if(Input.GetMouseButton(0)){
                head.transform.position = Vector3.MoveTowards(head.transform.position,new Vector3(head.transform.position.x,arm.transform.position.y,0),speed);
            }
            else if(release){
                arm.transform.position = Vector3.MoveTowards(arm.transform.position,new Vector3(arm.transform.position.x,head.transform.position.y+5,0),speed);
                release = false;
            }
            else{
                head.transform.position = Vector3.MoveTowards(head.transform.position,new Vector3(head.transform.position.x,arm.transform.position.y-5,0),speed);
            } 
        }
    }
}
