using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class ArcherEnnemy : Ennemy
{


    [SerializeField] protected float tempsCast; // faible temps où l'ennemi s'arrête pour tirer

    protected bool IsShooting; // Permet de savoir si la coroutine de shoot a commencé, pour pas spam
    protected bool IsCasting; // Permet de savoir quand pour le joueur se prépare à tirer, en gros s'il cast il arrête de marcher
    
    private IEnumerator Coroutine_Shoot() // un peu bordélique mais ca marche bien et en vrai chaque ligne est simple
    {
        IsShooting = true;
        yield return new WaitForSeconds(cadence_attack);
        IsCasting = true;
        yield return new WaitForSeconds(tempsCast * 0.75f);  // Ca marche mieux de laisser du temps après avoir tirer que partir juste après avoir tirer
        EnnemyProjectile lastProj = Instantiate(projectileEnnemy, transform.position, transform.rotation);
        lastProj.direction = get_direction_to(cible);
        yield return new WaitForSeconds(tempsCast * 0.25f );
        IsCasting = false;
        IsShooting = false;
    }
    
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (is_choosing_cible == false ) StartCoroutine(Coroutine_cible(MoveScriptPlayer.instanceP1.gameObject , MoveScriptPlayer.instanceP2.gameObject)); //Cible
        double distanceCible = get_distance_to(cible); 
        if (distanceCible > range && !IsCasting) move_to(get_direction_to(cible));             //Movement
        if (distanceCible < hittingRange && !IsShooting) StartCoroutine(Coroutine_Shoot());      //Attack
    }
}
