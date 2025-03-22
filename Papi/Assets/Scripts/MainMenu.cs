using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   public GameObject Main;
    public GameObject Options;
    public GameObject Credits;
    public AudioSource Mainsong;
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
    }
    public void CreditsB(){
        SFX.Play();
        Main.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(true);
    }
    public void OptionsB(){
        SFX.Play();
        Main.SetActive(false);
        Options.SetActive(true);
        Credits.SetActive(false);
    }

    public void PlayB(){
        SFX.Play();
        Mainsong.Stop();
        SceneManager.LoadScene("Paquito");
    }
    public void QuitB(){
        SFX.Play();
        Application.Quit();
    }
}
