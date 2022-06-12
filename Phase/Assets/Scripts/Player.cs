using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    private Rigidbody2D rb;
    public GameManager manager;

    [Header("States")]
    public bool isGrounded;
    public bool canmove;
    public bool isScrolling;

    [Header("Variables")]
    public float Speed;
    public float jump;
    public int gravScale;

    [Header("Input Info")]
    public float mousescroll;
    public float mousescrollmax;






    public void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        mousescroll = 1;
    }

    public void Update()
    {
        if (isGrounded)
        {

            if ((Input.GetKeyDown("w")) || (Input.GetKeyDown("space")))
            {


                rb.velocity = new Vector2(rb.velocity.x, jump);

                isGrounded = false;




            }


        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Scroll();
            isScrolling = true;
        }

        if (isScrolling)
        { 
            //canmove = false;
        }
        else
        {
            //canmove = true;
        }

        if (Input.GetMouseButtonDown(2))
        {
            ChangeWorld();
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

    public void Scroll()
    {
        mousescroll -= Input.GetAxis("Mouse ScrollWheel");

        mousescrollmax = manager.accessedWorlds;

       
        
        //restricts the mousescroll value to between 1 and the mousescrollmx value
        if (mousescroll < 1)
        { 
            mousescroll = mousescrollmax;
        }
        else if (mousescroll > mousescrollmax)
        {
            mousescroll = 1;
        }

        //activates the visual effects
        if (mousescroll != manager.currentWorld)
        {
            //then queue the visual overlapping effects 
        }

        

    }

    public void ChangeWorld()
    {
        //triggers the players choice of world
        if (Input.GetMouseButtonDown(2))
        {
            if (mousescroll != manager.currentWorld)
            {
                //removes the old world
                GameObject pastWorld = manager.worlds[manager.previousWorld - 1];
                rb.gravityScale = 0;
                pastWorld.SetActive(false);

                //brings in new world and updates information
                manager.currentWorld = (int)mousescroll;
                GameObject newWorld = manager.worlds[manager.currentWorld - 1];
                newWorld.SetActive(true);
                rb.gravityScale = gravScale;
                manager.previousWorld = manager.currentWorld; 

                
                
                
            }

            isScrolling = false;
            



        }
    }
}
