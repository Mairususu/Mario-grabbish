using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private static bool isPaused=false;
    public GameObject Pausemenu;
    [SerializeField] 

    private void Start(){
        Pausemenu.SetActive(false);   
    }
    public void ToMain(){
        SceneManager.LoadScene("Bait");
    }
    public void QuitB()
    {
        Application.Quit();
    }
    private void Update()
    {
        if (PauseButton) PauseGame();
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
