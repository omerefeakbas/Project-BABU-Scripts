using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);
        if(lifeTime<=0){
            Destroy(this.gameObject);
        }
        else{
            lifeTime-=Time.deltaTime;
        }
    }
}
