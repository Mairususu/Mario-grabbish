using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireEnnemy : ElementalEnnemies
{
    [SerializeField] private Sword_hitzone projectileExplosion;
    private bool canExplode;
    public int numBoost = 0;
    [SerializeField] private AudioSource Source;
    [SerializeField] private List<AudioClip> projectileSound;
    private void get_touched_by(PlayerProjectile.Element elem)
    { 
        switch (elem)
        {
            case PlayerProjectile.Element.Fire:
            {
                StartCoroutine(TakeHit(Color.green ));
                Source.clip=projectileSound[0];
                Source.Play();
                health += 1;
                klass.numBoost++; // c con d'avoir le truc stocké sur les deux je sais , mais j'ai fait les classes en un jour, y a des problèmes de hiérarchie...
                numBoost++;
                transform.localScale *= 1.4f;
                klass.hittingRange *= 1.4f;
            }; break;
            case PlayerProjectile.Element.Water:
            {
                Source.clip=projectileSound[1];
                Source.Play();
                health = 0  ;
                canExplode = false;
            } ;break;
            case PlayerProjectile.Element.Lightning:
            {
                Source.clip=projectileSound[2];
                Source.Play();
                StartCoroutine(TakeHit(Color.red));
                health -= 1; break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerProjectile p;
        if (other.TryGetComponent(out p))
        {
            get_touched_by(p.Myelement);
            Destroy(p.gameObject);
            
        }
    }

   private void explosion()
   {
       Sword_hitzone explosion = Instantiate(projectileExplosion, transform.position, transform.rotation); 
       for (int i = 0; i < numBoost; i++) explosion.transform.localScale *= 1.5f;

       explosion.cible = klass.cible;
       
   }

    // Start is called before the first frame update
    void Awake()
    {
        canExplode = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0) // Jsp pk il arrivait à mourir énormement de fois avant donc ca faisait buguer
        {
            if (canExplode) explosion();
            Destroy(gameObject);
        }
    }
}
