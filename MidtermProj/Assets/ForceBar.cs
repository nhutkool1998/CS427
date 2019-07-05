using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBar : MonoBehaviour
{
    // Start is called before the first frame update
    public float spaceHoldTime;
    public float upHodlTime;

    public float maxUpDegree;
    public float minUpDegree; 

    public float maxShootForce = 10;
    public float aimAngle;

    public GameObject gainedForceBar; 
    public GameObject character;
    public GameObject aimingCircle;
    public GameObject forceBarCompound;
    void Start()
    {
        //this.character = GameObject.Find("Character");    
    }

    // Update is called once per frame
    void Update()
    {
        this.aimAngle = this.aimingCircle.transform.rotation.z; 
       if (Input.GetKeyDown(KeyCode.Space))
        {
            this.spaceHoldTime = 0;
            aimingCircle.SetActive(true);
            forceBarCompound.SetActive(true);
        }

       else if (Input.GetKey(KeyCode.Space))
        {
            this.spaceHoldTime += Time.deltaTime; 
            var oldScale = this.gainedForceBar.transform.localScale;
            this.gainedForceBar.transform.localScale = new Vector3(this.spaceHoldTime / maxShootForce, oldScale.y, oldScale.z);
        }
        else if (Input.GetKeyUp(KeyCode.Space) && spaceHoldTime > 0)
        {

            this.character.GetComponent<CharacterMovement>().shootForce = this.spaceHoldTime;
            this.aimAngle = this.aimingCircle.transform.eulerAngles.z;
            this.character.GetComponent<CharacterMovement>().shootAngle = this.aimAngle; 
            this.character.GetComponent<CharacterMovement>().SendMessage("CharacterShoot");
            Debug.Log("Key up");
            aimingCircle.SetActive(false);
            forceBarCompound.SetActive(false); 
        }

        if (aimingCircle.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.upHodlTime = 0;
                //aimingCircle.SetActive(true);
                //forceBarCompound.SetActive(true);
            }

            else if (Input.GetKey(KeyCode.UpArrow))
            {
                this.upHodlTime += Time.deltaTime*1f;
                var oldScale = this.aimingCircle.transform.rotation;
                this.aimAngle = this.upHodlTime *   (maxUpDegree - minUpDegree) + minUpDegree;
                Debug.Log("aimAngle" + aimAngle); 
                if (this.aimAngle > maxUpDegree)
                    this.aimAngle = maxUpDegree;  
                this.aimingCircle.transform.eulerAngles = new Vector3(oldScale.x, oldScale.y,  this.aimAngle);
            }


             if (Input.GetKey(KeyCode.DownArrow))
            {
                this.upHodlTime -= Time.deltaTime * 1.0f;
                var oldScale = this.aimingCircle.transform.rotation;
                this.aimAngle = this.upHodlTime * (maxUpDegree - minUpDegree) + minUpDegree;
                Debug.Log("aimAngle" + aimAngle);
                if (this.aimAngle > maxUpDegree)
                    this.aimAngle = maxUpDegree;
                this.aimingCircle.transform.eulerAngles = new Vector3(oldScale.x, oldScale.y, this.aimAngle);
            }

        }

        //Debug.Log(spaceHoldTime); 
    }
}
