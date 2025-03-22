using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemy : Ennemy
{

    private void attack() // Pas encore implémenté le système de degats et d'attaquesdonc c vide c logique
    {
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (is_choosing_cible == false ) StartCoroutine(Coroutine_cible(MoveScriptPlayer.instanceP1.gameObject , MoveScriptPlayer.instanceP2.gameObject)); //Cible
        double distanceCible = get_distance_to(cible); 
        if (distanceCible > range) move_to(get_direction_to(cible));             //Movement
        if (distanceCible > hittingRange) attack();
    }
}
