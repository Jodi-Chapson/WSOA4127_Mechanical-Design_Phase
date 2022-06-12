using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{
    public string orbID;
    public bool triggered;
    public Canvas canvas;
    public GameManager manager;
    public Player player;
    public ParticleSystem ripple;
    public SpriteRenderer sprite;
    public void Start()
    {
        
        triggered = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("e") && triggered)
        {
            canvas.gameObject.SetActive(false);
            
            if (orbID == "Blue")
            {
                manager.accessedWorlds = 2;
                manager.WorldSelectorUpdate();

                player.ringarrow.SetActive(false);
                //removes the old world
                GameObject pastWorld = manager.worlds[manager.previousWorld - 1];

                player.rb.gravityScale = 0;
                pastWorld.SetActive(false);

                //brings in new world and updates information
                manager.currentWorld = 2;
                player.ringselector.rotation = Quaternion.Euler(0, 0, 180);
                for (int i = 0; i < manager.ghostworlds.Length; i++)
                {
                    manager.ghostworlds[i].SetActive(false);

                }

                GameObject newWorld = manager.worlds[2 - 1];
                player.background.sprite = manager.backgrounds[2 - 1];

                newWorld.SetActive(true);
                player.rb.gravityScale = player.gravScale;
                manager.previousWorld = manager.currentWorld;

                Debug.Log("blue");
                ripple.Play();
                sprite.enabled = false;
                


                Destroy(this.gameObject, 1f);
            }
            else if (orbID == "Purple")
            {
                manager.accessedWorlds = 3;
                manager.WorldSelectorUpdate();


                player.ringarrow.SetActive(false);
                //removes the old world
                GameObject pastWorld = manager.worlds[manager.previousWorld - 1];

                player.rb.gravityScale = 0;
                pastWorld.SetActive(false);

                //brings in new world and updates information
                manager.currentWorld = 3;
                player.ringselector.rotation = Quaternion.Euler(0, 0, 240);
                for (int i = 0; i < manager.ghostworlds.Length; i++)
                {
                    manager.ghostworlds[i].SetActive(false);

                }

                GameObject newWorld = manager.worlds[3 - 1];
                player.background.sprite = manager.backgrounds[3 - 1];

                newWorld.SetActive(true);
                player.rb.gravityScale = player.gravScale;
                manager.previousWorld = manager.currentWorld;

                ripple.Play();
                sprite.enabled = false;



                Destroy(this.gameObject, 1f);
            }



            




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
