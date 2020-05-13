using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    [SerializeField] private float speed;
    
    [SerializeField] private Camera cam;
    public bool isZoomed = true;

    void Update()
    {
        //zoom the camera smooothly
        if(!isZoomed){
            if(cam.orthographicSize < 16)
                cam.orthographicSize += speed*Time.deltaTime;
            if(cam.orthographicSize > 16)
                cam.orthographicSize = 16;
        }
        //unzoom the camera smooothly
        if(isZoomed){
            if(cam.orthographicSize > 8)
                cam.orthographicSize -= speed*Time.deltaTime;
            if(cam.orthographicSize < 8)
                cam.orthographicSize = 8;
        }
        
    }
    //Function for toggling the zoom phase (Button click event)
    public void ToggleZoom(){
        isZoomed = !isZoomed;
    }
}
