using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : Ennemy
{

    private void attack() // Pas encore implémenter le système de degats et d'attaquesdonc c vide c logique
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        double distanceCible = get_distance_to(cible); 
        if (distanceCible > range) move_to(get_direction_to(cible));             //Movement
        if (distanceCible > hittingRange) attack();
        
    }
}
