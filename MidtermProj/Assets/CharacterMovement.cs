using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP = 10.0f;
    public bool isSliding = false;
    public bool isJumping = false;
    public float llllll = 0.0f;
    public Rigidbody2D rigidBody2D;
    public float thrustForce = 100000.0f;
    public Animator animator;

    void Start()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) 
            animator.SetFloat("characterSpeed", 2.0f);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetFloat("characterSpeed", 2.0f);
        }
        else animator.SetFloat("characterSpeed", 0.0f); 
       

    }
    // Update is called once per frame
    private void Awake()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetFloat("characterSpeed", 2.0f);
           
        }
        else animator.SetFloat("characterSpeed", 0.0f);
    }

    void Update()
    {
        //float mmmmm = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //animator.SetFloat("characterSpeed", 2.0f);
            rigidBody2D.transform.Translate(Vector2.left*thrustForce);
            animator.SetFloat("characterSpeed", 2.0f);

            //animator.SetFloat("Speed", 0.2f); 
            //transform.position.Set(transform.position.x + thrustForce, transform.position.y, transform.position.z);

            //mmmmm = 2.0f;
        }
        else
            if (Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody2D.transform.Translate(Vector2.right*thrustForce);
            animator.SetFloat("characterSpeed", 2.0f);

            //animator.SetFloat("Speed", 0.2f); 
            //transform.position.Set(transform.position.x + thrustForce, transform.position.y, transform.position.z);

            //mmmmm = 2.0f;
        }

        //else llllll = 0;

        //animator.SetFloat("characterSpeed", mmmmm);
        //animator.SetBool("isSliding", isSliding);
        //animator.SetBool("isJumping", isJumping);
        //animator.SetFloat("HP", HP);
    }
}
