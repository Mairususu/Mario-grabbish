using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    public TextMeshProUGUI HPText;
    private static int pvs;
    private static int pvmax = 50;
    public GameObject DeathM;
    
    

    private void Start()
    {
        pvs = pvmax;
        Working();
    }
    public void Coll()
    {
        pvs -= 5;
        if(pvs <= 0){pvs = 0;}

        Working();
        if(pvs==0){GameOver();}
    }

    private void Working()
    {
        HPText.text=pvs.ToString()+"/"+pvmax.ToString();
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        DeathM.SetActive(true);
    }
}
