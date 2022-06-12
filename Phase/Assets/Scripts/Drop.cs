using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public GameObject respawnpoint;
    public CamController cam;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Player>().canmove = false;
            
            cam.Lerp = 1;
            collision.transform.position = new Vector3(respawnpoint.transform.position.x, respawnpoint.transform.position.y, respawnpoint.transform.position.z);
            
            cam.Lerp = 0.9f;
            collision.GetComponent<Player>().canmove = true;
            
        }
    }
}
