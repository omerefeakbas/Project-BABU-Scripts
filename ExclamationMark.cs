using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
 

public class ExclamationMark : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI exclamationMark;
    [SerializeField] private GameObject charPos;
    [SerializeField] float backTreshold;
    [SerializeField] float showTreshold;
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if(charPos.transform.position.x >= showTreshold){
            exclamationMark.color = Color.white;
            exclamationMark.fontSize = 0;
        }
        else{
            exclamationMark.color = new Color(Mathf.Round(charPos.transform.position.x/backTreshold*255),Mathf.Round(charPos.transform.position.x/backTreshold*128),0);
            exclamationMark.fontSize = Mathf.Round((charPos.transform.position.x-2)/(backTreshold-2)*6);
        }
    }
}
