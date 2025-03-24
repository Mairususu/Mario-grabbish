using UnityEngine;
using System;
using System.Collections;
using UnityEditor;
using Random = UnityEngine.Random;

public class ElementalEnnemies : MonoBehaviour
{
    [SerializeField] public Ennemy klassArcher;  // Références à remplir dans l'Inspector
    [SerializeField] public Ennemy klassMelee;
    [SerializeField] public int health;
    [SerializeField] public int damage;
    [SerializeField] protected EnnemyProjectile projectile;

    protected Ennemy klass;  // Déclare l'ennemi choisi
    
    [SerializeField] private SpriteRenderer spriteRenderer;



    protected IEnumerator TakeHit(Color color)
    {
        for (int i = 0; i < 2; i++) {
            spriteRenderer.color = color;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.1f);
        }
    }
    void Start()
    {
        // Assigne les joueurs aux ennemis
        // Ici ca change rien qu'on passe par klass melee ou archer car les deux classes ont les infos des persos
        klassArcher.Player_1 = MoveScriptPlayer.instanceP1.gameObject;
        klassMelee.Player_2 = MoveScriptPlayer.instanceP2.gameObject;

        int randomChoice = Random.Range(1, 3);
        if (randomChoice == 1)
        {
            klass = Instantiate(klassArcher, transform);
            klass.projectileEnnemy = projectile;
        }
        else klass = Instantiate(klassMelee, transform);
    }
}
