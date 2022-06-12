using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentWorld;
    public int previousWorld;
    public int accessedWorlds;
    
    public Player player;
    public Image scrollwheel;
    public Animator ringanimator;
    public GameObject[] worlds;
    public GameObject[] ghostworlds;
    public Sprite[] backgrounds;
    public Sprite[] colourwheel;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Player>();
        WorldSelectorUpdate();

    }

    // Update is called once per frame
    void Update()
    {
        //WorldSelectorUpdate();
    }

    public void WorldSelectorUpdate()
    {
        //turn this into a proper function

        
        if (accessedWorlds == 1)
        {
            
            StartCoroutine(RingAnimation(0));

            
        }
        else if (accessedWorlds == 2)
        {

            StartCoroutine(RingAnimation(1));
        }
        else if (accessedWorlds == 3)
        {
            StartCoroutine(RingAnimation(2));

        }
    }

    public IEnumerator RingAnimation(int spriteid)
    {
        ringanimator.Play("whiteflash", 0, 0f);

        yield return new WaitForSeconds(0.05f);

        scrollwheel.sprite = colourwheel[spriteid];
        

        


    }
}
