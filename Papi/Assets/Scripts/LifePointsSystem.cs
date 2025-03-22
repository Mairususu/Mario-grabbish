using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePointsSystem : MonoBehaviour
{
    public int pvs;
    public static int pvmax=50;

    void Start()
    {
        pvs = pvmax;
    }

    public void GameOver()
    {
        Debug.Log("MAMA MIA");
        DeathM.SetActive(false);
    }

    private void Update()
    {
        
    }
}
