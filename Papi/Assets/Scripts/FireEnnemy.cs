using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class FireEnnemy : ElementalEnnemies
{
    [SerializeField] private GameObject projectileExplosion;
    private bool canExplode;
    
    private void get_touched_by(PlayerProjectile.Element elem)
    { 
        switch (elem)
        {
            case PlayerProjectile.Element.Fire:
            {
                StartCoroutine(TakeHit(Color.green ));
                health += 1;
                transform.localScale *= 1.4f;
                klass.hittingRange *= 1.5f;
            }; break;
            case PlayerProjectile.Element.Water:
            {
                health = 0  ; 
                canExplode = false;
            } ;break;
            case PlayerProjectile.Element.Lightning:
            {
                StartCoroutine(TakeHit(Color.red));
                health -= 1; break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerProjectile p;
        if (other.TryGetComponent<PlayerProjectile>(out p))
        {
            get_touched_by(p.Myelement);
            Destroy(p.gameObject);
            
        }
    }

   private void explosion()
   {
       GameObject explosion = Instantiate(projectileExplosion, transform.position, Quaternion.identity);
   }

    // Start is called before the first frame update
    void OnSpawnPrefab()
    {
        canExplode = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0 )
        {
            if (canExplode) explosion();
            Destroy(gameObject);
        }
    }
}
