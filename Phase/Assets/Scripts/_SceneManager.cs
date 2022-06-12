using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{
    //basic script for changing and moving between scenes
    


    public int scenelevel;
    public void Scenechanger(int level)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(level);
    }

    public void Exit()
    {
        Application.Quit();
    }

   
}
