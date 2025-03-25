using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour
{
    public AudioSource SFX;

    public GameObject DEM;
    // Start is called before the first frame update
    
    void Start()
    {
        DEM.SetActive(false);
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
}
