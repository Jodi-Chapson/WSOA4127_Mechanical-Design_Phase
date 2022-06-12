using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isEnd;
    public GameObject nextlevelspawn;
    public bool triggered;
    public Canvas canvas;
    public GameManager manager;
    public Player player;
    public CamController cam;
    public GameObject endscreen;


    public void Update()
    {
        if (Input.GetKeyDown("e") && triggered)
        {
            if (isEnd)
            {
                //cue end screen
                player.canmove = false;
                endscreen.SetActive(true);
                Cursor.visible = true;
            }
            else
            {
                
                player.canmove = false;
                cam.Lerp = 1;
                player.transform.position = new Vector3 (nextlevelspawn.transform.position.x, nextlevelspawn.transform.position.y, nextlevelspawn.transform.position.z);
                cam.Lerp = 0.9f;
                player.canmove = true;
                
            }

            canvas.gameObject.SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == "Player")
        {
            triggered = true;

            canvas.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            triggered = false;

            canvas.gameObject.SetActive(false);
        }
    }
}
