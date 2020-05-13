using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpriteChanger : MonoBehaviour
{
    [SerializeField] private Sprite buttonPressedSprite;
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject actionText;
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject sparkSpawnPosition;
    [SerializeField] private GameObject sparksParticuleSystem;

    private Animator cameraAnimator;
    // Start is called before the first frame update

    void Start(){
        cameraAnimator = FindObjectOfType<CameraToggle>().GetComponentInParent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K)){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = buttonPressedSprite;
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        door.GetComponent<DoorToggle>().isButtonPressed = true;
        indicator.SetActive(false);
        actionText.SetActive(false);
        Instantiate(sparksParticuleSystem,sparkSpawnPosition.transform.position,Quaternion.identity,this.gameObject.transform);
        cameraAnimator.SetTrigger("Shake");
        SpriteChange.HandChange(false,"HandClick");
    }
    
}
