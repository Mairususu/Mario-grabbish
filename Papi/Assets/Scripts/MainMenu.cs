using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   public GameObject Main;
    public GameObject Options;
    public GameObject Credits;
    public GameObject Tutorial;
    public AudioSource SFX;

    // Start is called before the first frame update
    void Start()
    {
        MainB();
    }
    public void MainB()
    {
        SFX.Play();
        Main.SetActive(true);
        Options.SetActive(false);
        Credits.SetActive(false);
        Tutorial.SetActive(false);
    }
    public void CreditsB(){
        SFX.Play();
        Main.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(true);
        Tutorial.SetActive(false);
    }
    public void OptionsB(){
        SFX.Play();
        Main.SetActive(false);
        Options.SetActive(true);
        Credits.SetActive(false);
        Tutorial.SetActive(false);
    }

    public void TutoB()
    {
        SFX.Play();
        Main.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(false);
        Tutorial.SetActive(true);
        
    }
    public void PlayNowB(){
        SFX.Play();
        SceneManager.LoadScene("Bobinnzrd");
    }
    public void QuitB(){
        SFX.Play();
        Application.Quit();
    }
}
