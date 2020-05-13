using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour
{
    [SerializeField] private GameObject handOpen;
    [SerializeField] private GameObject handClick;
    public static GameObject go;
    public static GameObject go2;
    // Start is called before the first frame update
    void Start(){
        go = handClick;
        go2 = handOpen;
    }
    
    public static void HandChange(bool isActive,string name){
        if(name == "HandClick"){
            go.SetActive(isActive);
        }
        else if(name == "HandOpen"){
            go2.SetActive(isActive);
        }
        Debug.Log("BUM");
    }
}
