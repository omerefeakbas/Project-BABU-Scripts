using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangerScript : MonoBehaviour
{
    
    private bool isMoving = false;
    private bool isMovingEnded = false;
    private bool isGrabbedOnce = false;
    [SerializeField] private float speed;
    [SerializeField] private GameObject hanger;
    [SerializeField] private GameObject targetPosition;


    [SerializeField] private GameObject actionText;
    [SerializeField] private GameObject indicator;
    private Rigidbody2D charRb;


    //Animation fileds
    public Animator pulleyOneAnimator;
    public Animator pulleyTwoAnimator;
    private bool isAnimationStarted = true;

    //PS fields
    public GameObject spawnPosition;
    public GameObject particuleSystem;

    private Animator cameraAnimator;
    // Start is called before the first frame update
    

    void Start(){
        cameraAnimator = FindObjectOfType<CameraToggle>().GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving){
            
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position,targetPosition.transform.position,speed*Time.deltaTime);
            if(isAnimationStarted){
                pulleyOneAnimator.SetTrigger("StartRotation");
                pulleyTwoAnimator.SetTrigger("StartRotation");
                isAnimationStarted = false;
            }
                
            if(this.gameObject.transform.position.x >= targetPosition.gameObject.transform.position.x){
                isMovingEnded = true;
                isMoving = false;
            }

            if(Input.GetKeyDown(KeyCode.Space)){
                Release();
                SpriteChange.HandChange(true,"HandOpen");
            }
               
        }
        if(isMovingEnded){
            pulleyOneAnimator.SetTrigger("StopRotation");
            pulleyTwoAnimator.SetTrigger("StopRotation");
            Release();
            isMovingEnded = false;
            FindObjectOfType<StickToggle>().GetComponent<StickToggle>().release = true;
        }                  
    }

    void OnTriggerEnter2D(Collider2D collider){
        
        if(collider.GetType().Name == "CircleCollider2D" && !isGrabbedOnce){      

            Grab();

            indicator.SetActive(false);
            actionText.SetActive(false);
            Instantiate(particuleSystem,spawnPosition.transform.position,Quaternion.identity,this.gameObject.transform);

            isMoving = true;
            
            this.gameObject.transform.position = new Vector3(collider.gameObject.transform.position.x-0.15f,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
            cameraAnimator.SetTrigger("Shake");
            isGrabbedOnce = true;
        }
            
    }
    

    private void Release(){
        try{
            FindObjectOfType<StickToggle>().GetComponent<StickToggle>().isHanged = false;
            FindObjectOfType<StickToggle>().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            FindObjectOfType<StickToggle>().GetComponent<Rigidbody2D>().velocity = Vector2.down;

        }
        catch{
            return;
        }
        
    }

    private void Grab(){
        FindObjectOfType<StickToggle>().GetComponent<StickToggle>().isHanged = true;
        FindObjectOfType<StickToggle>().GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;;
        SpriteChange.HandChange(false,"HandOpen");
    }
   
}
