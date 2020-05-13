using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToggle : MonoBehaviour
{
    public bool isButtonPressed = false;
    [SerializeField] private float speed;
    [SerializeField] private float yPos = -1.15f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
            isButtonPressed = true;

        if(isButtonPressed){
            this.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,new Vector3(this.gameObject.transform.position.x,yPos,this.gameObject.transform.position.z),speed*Time.deltaTime);
        }
            
    }
    
}
