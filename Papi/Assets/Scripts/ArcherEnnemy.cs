using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class ArcherEnnemy : Ennemy
{


    [SerializeField] protected float projectile_speed; // Ptdr je comptais pas du tout taper ça, mais c'est pas con de serialize ca xD
    [SerializeField] protected float temps_cast; // faible temps où l'ennemi s'arrête pour tirer

    protected bool is_shooting; // Permet de savoir si la coroutine de shoot a commencé, pour pas spam
    protected bool is_casting; // Permet de savoir quand pour le joueur se prépare à tirer, en gros s'il cast il arrête de marcher
    
    private IEnumerator Coroutine_Shoot() // un peu bordélique mais ca marche bien et en vrai chaque ligne est simple
    {
        is_shooting = true;
        yield return new WaitForSeconds(cadence_attack);
        is_casting = true;
        yield return new WaitForSeconds(temps_cast * 0.75f);  // Ca marche mieux de laisser du temps après avoir tirer que partir juste après avoir tirer
        EnnemyProjectile lastProj = Instantiate(projectileEnnemy, transform.position, transform.rotation);
        lastProj.direction = get_direction_to(cible);
        lastProj.projectileSpeed = projectile_speed;
        yield return new WaitForSeconds(temps_cast * 0.25f );
        is_casting = false;
        is_shooting = false;
    }
    
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (is_choosing_cible == false ) StartCoroutine(Coroutine_cible(MoveScriptPlayer.instanceP1.gameObject , MoveScriptPlayer.instanceP2.gameObject)); //Cible
        double distanceCible = get_distance_to(cible); 
        if (distanceCible > range && !is_casting) move_to(get_direction_to(cible));             //Movement
        if (distanceCible < hittingRange && !is_shooting) StartCoroutine(Coroutine_Shoot());      //Attack
    }
}
