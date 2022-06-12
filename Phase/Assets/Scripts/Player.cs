using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;

    [Header("States")]
    public bool isGrounded;
    public bool canmove;

    [Header("Variables")]
    public float Speed;
    public float jump;
    public int gravScale;

    
    
    
    

    public void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (isGrounded)
        {

            if (Input.GetKeyDown("w"))
            {


                rb.velocity = new Vector2(rb.velocity.x, jump);

                isGrounded = false;




            }


        }
    }
    public void FixedUpdate()
    {


        if (canmove)
        {
            if (Input.GetKey("d"))
            {
                rb.velocity = new Vector2(Speed, rb.velocity.y);
                //Flip();
            }
            else if (Input.GetKey("a"))
            {
                rb.velocity = new Vector2(-Speed, rb.velocity.y);

                //Flip();
            }
            //else
            //{
                
            //    rb.velocity = new Vector2(0, rb.velocity.y);
                
            //}



            

            if (isGrounded)
            
            {
                rb.gravityScale = gravScale;
            }
            else if (!isGrounded && rb.velocity.y < 0)
            {
                rb.gravityScale = gravScale + 2;

                
            }
               




        }
    }
}
