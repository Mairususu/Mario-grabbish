using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private static bool isPaused=false;
    public GameObject Pausemenu;

    private void Start(){
        Pausemenu.SetActive(false);   
    }
    public void Tomain(){
        SceneManager.LoadScene("Bait");
    }
    public void QuitB()
    {
        Application.Quit();
    }
    
    public void PauseGame(){
        if (isPaused)
        {
            Time.timeScale=1;
            Pausemenu.SetActive(false);
        }
        else
        {
            Time.timeScale=0;
            Pausemenu.SetActive(true);
        }
        isPaused=!isPaused;
    }

    
}
