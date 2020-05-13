using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool isMoving = false;
    public float moveSpeed;
    public GameObject targetPos;

    [SerializeField]
    private GameObject activatedParticuleSystem;
    
    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,targetPos.transform.position,moveSpeed*Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(){
        isMoving = true;
        activatedParticuleSystem.SetActive(true);
    }
}
