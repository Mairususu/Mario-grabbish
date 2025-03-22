using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour
{
    public AudioSource SFX;
    // Start is called before the first frame update
    
    void Start()
    {
        gameObject.SetActive(false);
    }
    
    public void ToMain(){
        SFX.Play();
        SceneManager.LoadScene("Bait");
    }
    public void QuitB()
    {
        SFX.Play();
        Application.Quit();
    }
}
