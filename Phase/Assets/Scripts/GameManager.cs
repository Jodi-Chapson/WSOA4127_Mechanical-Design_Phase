using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentWorld;
    public int previousWorld;
    public int accessedWorlds;
    
    public Player player;
    public GameObject[] worlds;
    
    
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
