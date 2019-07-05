using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP = 10.0f;
    public bool isSliding = false;
    public bool isJumping = false;

    public Rigidbody2D rigidBody2D;
    public float thrustForce = 1000000f;
    public bool isGrounded = true; 

    public float jumpAngle, jumpForce;

    public Animator animator;
    private GameObject iceBolt; 
    public int direction = 1;

    public GameObject projectile;
    public float shootAngle;
    public float shootForce;

    private float preX; 
    //private float spaceHoldTime; 

    void Start()
    {
        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) 
        //animator.SetFloat("characterSpeed", 2.0f);
    }

    private void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        //{
        //    animator.SetFloat("characterSpeed", 2.0f);
        //}
        //else animator.SetFloat("characterSpeed", 0.0f); 


    }
    // Update is called once per frame
    private void Awake()
    {
        preX = transform.position.x; 
        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        //{
        //    animator.SetFloat("characterSpeed", 2.0f);

        //}
        //else animator.SetFloat("characterSpeed", 0.0f);
    }

    void Update()
    {
        //float mmmmm = 0;
        //animator.SetFloat("characterSpeed", 0.0f);
        //if (Input.GetKey(KeyCode.UpArrow) && isGrounded)
        //{
        //    //transform.Translate(Vector2.up*3);
        //    float forceY = -Mathf.Sin(jumpAngle) * jumpForce * 2;
        //    float forceX = -direction*Mathf.Cos(jumpAngle) * jumpForce / 2;
        //    Debug.Log(forceX + " " + forceY); 
        //    rigidBody2D.AddForce(new Vector2(forceX, forceY));
        //    isGrounded = false;
        //    isJumping = true;
        //    Debug.Log("jumping!"); 

        //}
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //animator.SetFloat("characterSpeed", 2.0f);
            //animator.SetFloat("characterSpeed", 2.0f);
            //transform.Translate(Vector2.left * thrustForce);
            direction = -1;
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * direction, transform.localScale.y, transform.localScale.z);
            float forceX = direction*jumpForce/3;
            float forceY = 0;
            rigidBody2D.AddForce(new Vector2(forceX, forceY));

            //animator.SetFloat("characterSpeed", 2.0f);

            //animator.SetFloat("Speed", 0.2f); 
            //transform.position.Set(transform.position.x + thrustForce, transform.position.y, transform.position.z);

            //mmmmm = 2.0f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //animator.SetFloat("characterSpeed", 2.0f);
            //transform.Translate(Vector2.right * thrustForce*thrustForce);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            direction = 1;
            float forceX = direction * jumpForce /3;
            float forceY = 0; 
            rigidBody2D.AddForce(new Vector2(forceX, forceY));
            //animator.SetFloat("Speed", 0.2f); 
            //transform.position.Set(transform.position.x + thrustForce, transform.position.y, transform.position.z);

            //mmmmm = 2.0f;
        }



        //else llllll = 0;
        var deltaX = Mathf.Abs(transform.position.x - preX);
        preX = transform.position.x; 
        animator.SetFloat("characterSpeed", deltaX);

        //animator.SetBool("isSliding", isSliding);
        animator.SetBool("isJumping", isJumping);
        //animator.SetFloat("HP", HP);
    }
    public void CharacterShoot()
    {
        if (iceBolt == null || true)
        {
            iceBolt = Object.Instantiate(projectile);
            var orb = transform.GetChild(0);
            iceBolt.transform.position = new Vector3(orb.position.x+0.05f, orb.transform.position.y+0.2f, orb.position.z);
            //iceBolt.transform.position = new Vector3(transform.position.x, transform.position.y - orb.transform.position.y, transform.position.y);

            var icePath = iceBolt.GetComponent<icePath>();
            icePath.throwAngle = shootAngle;

            if (direction <0)
                icePath.throwAngle = 180+shootAngle;

            icePath.throwForce = shootForce; 
            icePath.SendMessage("Shoot");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision entered");
        if (collision.gameObject.tag == "platform")
        {
            Debug.Log("Grounded!!!");
            isGrounded = true;
            isJumping = false;
            animator.SetBool("isJumping", isJumping);

        }
    }

   
}
