using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPSystem : MonoBehaviour
{
    [SerializeField] private LifePointsSystem lp;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        lp.pvs -= 5;
        if(lp.pvs <= 0){lp.pvs = 0;}
    }
}
