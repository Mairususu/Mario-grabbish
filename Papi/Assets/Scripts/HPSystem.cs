using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    public Image fill;
    private static int pvs;
    private static int pvmax=50;
    public GameObject DeathM;
    
    

    private void Start()
    {
        pvs = pvmax;
    }
    public void Coll()
    {
        pvs -= 5;
        if(pvs <= 0){pvs = 0;}

        Damage();
        if(pvs==0){GameOver();}
    }

    private void Damage()
    {
        fill.rectTransform.anchorMax.Set((float)((float)pvs/(float)pvmax),1.0f);
        Debug.Log(((float)pvs/(float)pvmax) + " => " +fill.rectTransform.anchorMax);
    }
    public void GameOver()
    {
        Debug.Log("MAMA MIA");
        Time.timeScale = 0;
        DeathM.SetActive(true);
    }
}
