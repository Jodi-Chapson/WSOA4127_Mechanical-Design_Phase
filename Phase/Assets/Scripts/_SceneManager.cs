using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    //basic script for changing and moving between scenes

    public Player player;
    public GameObject pausemenu;
    public Texture2D cursortext;
    public CursorMode cursormode = CursorMode.Auto;
    public Vector2 hotspot = Vector2.zero;

    public bool paused;
    public int scenelevel;
    

    public void Start()
    {
        paused = false;
        Cursor.SetCursor(cursortext, hotspot, cursormode);
    }
    public void Scenechanger(int level)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        paused = true;
        Time.timeScale = 0f;
        player.canmove = false;


        //closes the scroll wheel ui 
        pausemenu.SetActive(true);
        Cursor.visible = true;

    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        pausemenu.SetActive(false);
        Cursor.visible = false;

        player.canmove = true;
        paused = false;
    }

   
}
