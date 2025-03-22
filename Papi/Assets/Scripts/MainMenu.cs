using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{   public GameObject Main;
    public GameObject Options;
    public GameObject Credits;
    public AudioSource Mainsong;

    // Start is called before the first frame update
    void Start()
    {
        MainB();
        Mainsong.Play();
    }
    public void MainB(){
        Main.SetActive(true);
        Options.SetActive(false);
        Credits.SetActive(false);
    }
    public void CreditsB(){
        Main.SetActive(false);
        Options.SetActive(false);
        Credits.SetActive(true);
    }
    public void OptionsB(){
        Main.SetActive(false);
        Options.SetActive(true);
        Credits.SetActive(false);
    }

    public void PlayB(){
        Mainsong.Stop();
        SceneManager.LoadScene("Paquito");
    }
    public void QuitB(){
        Application.Quit();
    }
}
