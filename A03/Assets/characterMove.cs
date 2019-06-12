using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    // Start is called before the first frame update
    private readonly Dictionary<int,Sprite> left;
    private readonly Dictionary<int, Sprite> right;


    private readonly Dictionary<int, Sprite> up;

    private readonly Dictionary<int, Sprite> down;
 
    public Sprite left1;

    public Sprite left2;
    public Sprite left3;

    public Sprite right1;
    public Sprite right2;
    public Sprite right3;

    public Sprite up1;
    public Sprite up2;
    public Sprite up3;

    public Sprite down1;
    public Sprite down2;
    public Sprite down3;

    private int upStep = 0, downStep = 0, leftStep = 0, rightStep = 0;

    void Start()
    {
        left.Add(0, left1);
        left.Add(1, left2);
        left.Add(2, left3);

        right.Add(0, right1);
        right.Add(1, right2);
        right.Add(2, right3);

        up.Add(0, up1);
        up.Add(1, up2);
        up.Add(2, up3);

        down.Add(0, down1);
        down.Add(1, down2);
        down.Add(2, down3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
          //  transform.Translate(new Vector3(-0.1f, 0, 0));
            leftStep+=1;
            leftStep %= 3;
            downStep = 0;
            rightStep = 0;
            upStep = 0;
         //   GetComponent<SpriteRenderer>().sprite = left[leftStep]; 
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
       //     transform.Translate(new Vector3(0.1f, 0, 0));
            leftStep = 0;
            downStep += 1;
            rightStep = 0;
            upStep = 0;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
         
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 10.0f, 0)); 
        }
    }
}
