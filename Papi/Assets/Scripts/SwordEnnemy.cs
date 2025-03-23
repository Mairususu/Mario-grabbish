using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemy : Ennemy
{

    private bool is_attacking; 
    private IEnumerator Coroutine_attack() // Pas encore implémenté le système de degats et d'attaquesdonc c vide c logique
    {
        is_attacking = true;
        yield return new WaitForSeconds(cadence_attack);  // Ca marche mieux de laisser du temps après avoir tirer que partir juste après avoir tirer
        EnnemyProjectile lastProj = Instantiate(projectileEnnemy, transform.position, transform.rotation);
        is_attacking = false;
    }

    // Start is called before the first frame update

    // Update is called once per frame
    void Update() // La je sais qu'Aikeon m'avait montré un truc pour réussir à faire un virtual override meme si c'est un event mais je m'en souviens pas, mais ca pourrait opti avec archerennermy car les 3 premières lignes sont les memes
    {
        if (is_choosing_cible == false ) StartCoroutine(Coroutine_cible(MoveScriptPlayer.instanceP1.gameObject , MoveScriptPlayer.instanceP2.gameObject)); //Cible
        double distanceCible = get_distance_to(cible); 
        if (distanceCible > range) move_to(get_direction_to(cible));             //Movement
        if (distanceCible > hittingRange && !is_attacking) StartCoroutine(Coroutine_attack());
    }
}
