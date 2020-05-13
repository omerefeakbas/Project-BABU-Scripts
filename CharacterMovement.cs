using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    
    public float timeDelay;
    
    private Rigidbody2D rb;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public float jumpForce;
    public GameObject gameOverPanel;
    public bool isMovingForward;


    public Animator robotAnimator;
    public Robot robot;

  
    public GameObject destroyParticuleSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        isMovingForward = false;
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);
    }
    void Update(){
        if(isMovingForward){
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position,new Vector3(0,gameObject.transform.position.y,gameObject.transform.position.z),20*Time.deltaTime);
            if(gameObject.transform.position.x == 0)
                isMovingForward = false;
        }
    }
    void LateUpdate(){
        if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1)) && isGrounded == true){
            
            SoundPlayer.PlaySound("Player_Jump_" + Random.Range(1,3).ToString());
            rb.velocity = Vector2.up * jumpForce;
        }  
    }
    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject.name == "BackTreshold"){
            Instantiate(destroyParticuleSystem,gameObject.transform.position,Quaternion.identity);
            robotAnimator.SetTrigger("Punch");
            robot.robotFace.texture = robot.happySprite.texture;
        
            Destroy(gameObject);
            Debug.Log("Game is F*ckin over!");
            SoundPlayer.PlaySound("Player_Die_1");
            gameManager.HandleGameOver();
            //gameOverPanel.SetActive(true);
        }
        else if(collider.gameObject.tag == "Trap"){
            Instantiate(destroyParticuleSystem,gameObject.transform.position,Quaternion.identity);
            robot.robotFace.texture = robot.happySprite.texture;
            Destroy(gameObject);
            Debug.Log("Trap");
            SoundPlayer.PlaySound("Player_Die_1");
            gameManager.HandleGameOver();
            //gameOverPanel.SetActive(true);
        }
    }
}
