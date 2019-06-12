using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
 

    public bool grounded = true;
    public float jumpForce = 200;
  
    private Rigidbody2D rb2d;

    private bool jump = true;
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
           JumpCharacter();
        }
    }

    void JumpCharacter()
    {
        if (true)
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
        if (collision.gameObject.name == "platform")
            grounded = true; 
    }
}
