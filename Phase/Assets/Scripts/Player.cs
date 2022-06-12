using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;
    public GameManager manager;
    public SpriteRenderer background;
    public GameObject ringarrow;
    public RectTransform ringselector;

    [Header("States")]
    public bool isGrounded;
    public bool canmove;
    public bool isScrolling;

    [Header("Variables")]
    public float Speed;
    public float jump;
    public int gravScale;
    public Vector3 targetrotation;
    public Vector3 currentrotation;
    public float Lerp;

    [Header("Input Info")]
    public float mousescroll;
    public float mousescrollmax;






    public void Start()
    {
        Cursor.visible = false;
        rb = this.GetComponent<Rigidbody2D>();
        currentrotation = Vector3.zero;
        targetrotation = Vector3.zero;
        mousescroll = 1;
    }

    public void Update()
    {
        
        if (Input.GetKeyDown("escape"))
        {
            manager.GetComponent<_SceneManager>().Pause();
        }

        if(targetrotation.z == 240 && currentrotation.z == 0)
        {
            ringselector.rotation = Quaternion.Euler(0,0, 360);
            currentrotation.z = 360;

        }
        else if (targetrotation.z == 0 && currentrotation.z == 240)
        {
            ringselector.rotation = Quaternion.Euler(0, 0, -120);
            currentrotation.z = -120;
        }

        currentrotation = Vector3.Lerp(currentrotation, targetrotation, Lerp);
        ringselector.rotation = Quaternion.Euler(currentrotation);

 

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

        if (Input.GetMouseButtonDown(2) && manager.GetComponent<_SceneManager>().paused == false)
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
            else
            {
                
                rb.velocity = new Vector2(0, rb.velocity.y);
                
            }



            

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

            for (int i = 0; i < manager.ghostworlds.Length; i++)
            {
                if (i != mousescroll - 1)
                {

                    manager.ghostworlds[i].SetActive(false);
                }
                else
                {
                    manager.ghostworlds[i].SetActive(true);

                }

            }

            


            
        }
        else
        {
            for (int i = 0; i < manager.ghostworlds.Length; i++)
            {
                manager.ghostworlds[i].SetActive(false);
                
            }
        }


        ringarrow.SetActive(true);
        if (manager.accessedWorlds == 1)
        {
            //only one worlds, so do nothing
            targetrotation = new Vector3(0, 0, 0);
        }
        else if (manager.accessedWorlds == 2)
        {
            //two worlds
            if (mousescroll == 1)
            {
                targetrotation = new Vector3(0, 0, 0);
            }
            else if (mousescroll == 2)
            {
                targetrotation = new Vector3(0, 0, 180);
            }
        }
        else if (manager.accessedWorlds == 3)
        {
            
            //three worlds

            if (mousescroll == 1)
            {
                targetrotation = new Vector3(0, 0, 0);
            }
            else if (mousescroll == 2)
            {
                targetrotation = new Vector3(0, 0, 120);
            }
            else if (mousescroll == 3)
            {
                targetrotation = new Vector3(0, 0, 240);
            }


        }



    }

    public void ChangeWorld()
    {
        //triggers the players choice of world
        if (Input.GetMouseButtonDown(2))
        {
            if (mousescroll != manager.currentWorld)
            {

                ringarrow.SetActive(false);
                //removes the old world
                GameObject pastWorld = manager.worlds[manager.previousWorld - 1];
                
                rb.gravityScale = 0;
                pastWorld.SetActive(false);

                //brings in new world and updates information
                manager.currentWorld = (int)mousescroll;
                for (int i = 0; i < manager.ghostworlds.Length; i++)
                {
                    manager.ghostworlds[i].SetActive(false);

                }
                
                GameObject newWorld = manager.worlds[manager.currentWorld - 1];
                background.sprite = manager.backgrounds[manager.currentWorld - 1];
                
                newWorld.SetActive(true);
                rb.gravityScale = gravScale;
                manager.previousWorld = manager.currentWorld; 

                
                
                
            }

            isScrolling = false;
            



        }
    }



}
