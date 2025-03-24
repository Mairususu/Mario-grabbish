using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;


public class Ennemy : MonoBehaviour
{



    [SerializeField] public double speed;
    [SerializeField] public float cadence_changement_de_cible;
    [SerializeField] protected float cadence_attack; // Range à partir de laquelle ils peuvent te tirer dessus, ou te mettre un coup d'épée  doit être + grand que range obligatoirement 
    [SerializeField] public GameObject Player_1;
    [SerializeField] public GameObject Player_2;
    [SerializeField] protected double range; // Range à partir de laquelle ils n'approchent plus (grand pour archer, très faible pour melee) (à régler dans les préfab
    [SerializeField] public double hittingRange; // Range à partir de laquelle ils peuvent te tirer dessus, ou te mettre un coup d'épée  doit être + grand que range obligatoirement 
    [SerializeField] public EnnemyProjectile projectileEnnemy; //Ca sert que pour l'archer mais le mettre que dans la classe fille me fait bien chier '
    [SerializeField] public Sword_hitzone swordhitzone; // idem que pour melee mais chiant si en dessous
    
    
    protected bool is_choosing_cible = false; // Permet de savoir si la coroutine de choix de cible est lancé ou s'il faut la relancer
    public GameObject cible; //Ne pas mettre de GO dans ce prefab, il va se remplir automatiquement en choisissant soit p1 ou p2 en fonction de leur distance à l'ennemi

    public Vector3 get_direction_to(GameObject cible) // Permet d'obtenir la direction normalisé de n'importe quel Gameobject qu'on lui fournit
    {
        return (cible.transform.position - transform.parent.position).normalized;
    }

    public void move_to(Vector3 direction) // Bouge dans la direction (doit être normalisé) fournie, notamment le joueur cible
    {
        transform.parent.position += direction * (float)(Time.deltaTime * speed);
    }

    protected double get_distance_to(GameObject g1)
    {
        return Vector3.Distance(transform.parent.position, g1.transform.position);
    }

    public void cible_choose(GameObject g1, GameObject g2)
    {
        if (get_distance_to(g1) <= get_distance_to(g2))
            cible = g1;
        else cible = g2;
    }

    protected IEnumerator Coroutine_cible(GameObject p1, GameObject p2)
    {
        is_choosing_cible = true;
        cible_choose(p1, p2);
        yield return new WaitForSeconds(cadence_changement_de_cible);
        is_choosing_cible = false;
    }

    private void Awake()
    {
        Player_1 = MoveScriptPlayer.instanceP1.gameObject;
        Player_2 = MoveScriptPlayer.instanceP2.gameObject;
        StartCoroutine(Coroutine_cible(MoveScriptPlayer.instanceP1.gameObject, MoveScriptPlayer.instanceP2.gameObject));
    } 
}