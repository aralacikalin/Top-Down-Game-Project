using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    public Rigidbody rb;
    public float speed;
    private Vector3 movement = Vector3.zero;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCharacter();
        
        //this.gameObject.transform.eulerAngles = movement;
    }
    void moveCharacter()
    {
        /*
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        Vector3 rbV = (rb.velocity);
        float deltaTime = 0.02f; // Time.deltaTime;
        float updatedSpeed = speed * deltaTime;

        if (inputV > 0)
        {
            anim.SetBool("Walk_Anim", true);
            //transform.Translate(0,updatedSpeed,0);
            rb.velocity = new Vector3(inputH * updatedSpeed, inputV * updatedSpeed, rbV.z);
        }
        else if (inputV < 0)
        {
            anim.SetBool("Walk_Anim", true);
            //transform.Translate(0f, -updatedSpeed, 0f);
            this.gameObject.transform.Rotate(0, 90, 0);
            rb.velocity = new Vector3(inputH * updatedSpeed, inputV * updatedSpeed, rbV.z);
        }
        else if (inputH < 0)
        {
            anim.SetBool("Walk_Anim", true);
            //transform.Translate(-updatedSpeed, 0f, 0f);
            this.gameObject.transform.Rotate(0, -90, 0);
            rb.velocity = new Vector3(inputH * updatedSpeed, inputV * updatedSpeed, rbV.z);
        }
        else if (inputH > 0)
        {
            anim.SetBool("Walk_Anim", true);
            //transform.Translate(updatedSpeed, 0f, 0f);
            rb.velocity = new Vector3(inputH * updatedSpeed, inputV * updatedSpeed, rbV.z);
        }
        else
        {
            anim.SetBool("Walk_Anim", false);
            rb.velocity = new Vector3(0f, 0f, 0f);
        }
        */


         float inputH = Input.GetAxis("Horizontal");
         float inputV = Input.GetAxis("Vertical");
         Vector3 rbV = (rb.velocity);
         float deltaTime = 0.02f; // Time.deltaTime;
         float updatedSpeed = speed * deltaTime;

        if (inputH != 0 || inputV != 0)
         {
             //Checks the direction of the movement
            if (inputH < 0)
             {
                 movement[1] -= updatedSpeed;
                 anim.SetInteger("State", 2);
             }
             else if (inputH > 0)
             {
                 movement[1] += updatedSpeed;
                 anim.SetInteger("State", 1);
             }
             rb.velocity = new Vector3(inputH * updatedSpeed, inputV * updatedSpeed, rbV.z);
         }
         else
         {
             rb.velocity = new Vector3(0, 0, 0);
             anim.SetInteger("State", 0);
         }
         
    }
}
