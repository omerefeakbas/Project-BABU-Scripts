using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Robot : MonoBehaviour
{
    [SerializeField] private Animator robotAnimator;
    [SerializeField] private GameObject character;
    [SerializeField] private float triggerTheshold;
    public RawImage robotFace;
    [SerializeField] private Sprite angrySprite;
    [SerializeField] private Sprite evilSprite;
    public Sprite happySprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        try{
            if(character.transform.position.x < triggerTheshold){
                robotAnimator.SetBool("isCharClose",true);
                robotFace.texture = evilSprite.texture;

            }
            else{
                robotAnimator.SetBool("isCharClose",false);
                robotFace.texture = angrySprite.texture;
            }
        }
        catch{
            return;
        }

    }
}
