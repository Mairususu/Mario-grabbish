using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private static bool isPaused=false;
    public GameObject Pausemenu;
    public AudioSource SFX;

    private void Start(){
        Pausemenu.SetActive(false);   
    }
    public void ToMain(){
        SFX.Play();
        Time.timeScale=1;
        SceneManager.LoadScene("Bait");
    }
    public void QuitB()
    {
        SFX.Play();
        Application.Quit();
    }
    
    private void Update()
    {
        if (Input.GetButtonDown("Pause")) PauseGame();
    }

    public void PauseGame()
    {
        
        if (isPaused)
        {
            SFX.Play();
            Time.timeScale=1;
            Pausemenu.SetActive(false);
        }
        else
        {
            Time.timeScale=0;
            Pausemenu.SetActive(true);
            SFX.Play();
        }
        isPaused=!isPaused;
    }

    
}
