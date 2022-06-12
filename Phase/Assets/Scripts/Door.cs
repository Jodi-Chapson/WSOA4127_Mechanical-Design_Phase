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


    public void Update()
    {
        if (Input.GetKeyDown("e") && triggered)
        {
            if (isEnd)
            {
                //cue end screen
            }
            else
            {
                //cam.CamFollow
                player.canmove = false;
                player.transform.position = new Vector3 (nextlevelspawn.transform.position.x, nextlevelspawn.transform.position.y, nextlevelspawn.transform.position.z);
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
