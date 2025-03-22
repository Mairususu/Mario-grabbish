using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class ArcherEnnemy : Ennemy
{


    [SerializeField] protected GameObject projectileEnnemy;

    private void Shoot()
    {
        Instantiate(projectileEnnemy, transform.position, quaternion.identity);
    }
    
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (is_choosing_cible == false ) StartCoroutine(Coroutine_cible(MoveScriptPlayer.instanceP1.gameObject , MoveScriptPlayer.instanceP2.gameObject)); //Cible
        double distanceCible = get_distance_to(cible); 
        if (distanceCible > range) move_to(get_direction_to(cible));             //Movement
        //if (distanceCible > hittingRange) Shoot();      //Attack

    }
}
