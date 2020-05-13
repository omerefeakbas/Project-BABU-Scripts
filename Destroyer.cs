using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private float lifetime = 1f;

    // Update is called once per frame
    void Update()
    {
        if(lifetime <= 0)
            Destroy(this.gameObject);
        lifetime -= Time.deltaTime;
    }
}
