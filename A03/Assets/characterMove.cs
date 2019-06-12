using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
 

    private int upStep = 0, downStep = 0, leftStep = 0, rightStep = 0;
    public bool grounded = false;
    public float jumpForce = 0.1f;
    public Transform groundCheck;
    private Rigidbody2D rb2d;

    private bool jump = false;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-0.1f, 0, 0));
          
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(0.1f, 0, 0));
        }
       
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.Translate(new Vector3, Space.World);
           if (jump) JumpCharacter();
        }
    }

    void JumpCharacter()
    {
        if (grounded)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            grounded = false;
        }
        jump = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.name == "boss")
         this.gameObject.SetActive(false);
    }
}
