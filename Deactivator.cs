using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivator : MonoBehaviour
{
    public float lifetime;
    private float lifetimeValue;

    void Start(){
        lifetimeValue = lifetime;
    }
    // Update is called once per frame
    void Update()
    {
        if(lifetime <= 0){
            this.gameObject.SetActive(false);
            lifetime = lifetimeValue;
        }
        else
            lifetime -= Time.deltaTime;
    }
}
