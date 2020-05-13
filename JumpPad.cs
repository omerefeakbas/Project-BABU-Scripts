using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField]
    private float pushForce;

    [SerializeField]
    private GameObject particuleSystem;

    [SerializeField]
    private GameObject actionText;

    [SerializeField]
    private GameObject activatedParticuleSystem;

    private Animator cameraAnimator;
    // Start is called before the first frame update
    

    void Start(){
        cameraAnimator = FindObjectOfType<CameraToggle>().GetComponentInParent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * pushForce;
        particuleSystem.SetActive(false);
        actionText.SetActive(false);
        activatedParticuleSystem.SetActive(true);
        cameraAnimator.SetTrigger("Shake");
    }
}
