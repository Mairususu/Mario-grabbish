
using System.Collections.Generic;
using UnityEngine;


public class WaterEnnemy : ElementalEnnemies
{
    [SerializeField] public PlayerProjectile projFoudre;
    [SerializeField] private AudioSource Source;
    [SerializeField] private List<AudioClip> projectileSound;
        
    private void get_touched_by(PlayerProjectile.Element elem)
    { 
        switch (elem)
        {
            case PlayerProjectile.Element.Nature:
            {
                StartCoroutine(TakeHit(Color.yellow));
                Source.clip=projectileSound[0];
                Source.Play();
                health -= 1;
                transform.localScale *= 0.6f;
                klass.speed *= 1.5f;
            } break;
            case PlayerProjectile.Element.Water:
            {
                StartCoroutine(TakeHit(Color.red));
                Source.clip=projectileSound[1];
                Source.Play();
                health -= 1  ;break;
            }
            case PlayerProjectile.Element.Lightning:
            {
                Source.clip=projectileSound[2];
                Source.Play();
                Vector3 baseDirection = klass.get_direction_to(klass.cible);
                for (int i = 0; i < 4; i++)
                {
                    Vector3 rotatedDirection = Quaternion.Euler(0, 0, i * 90) * baseDirection;
                    PlayerProjectile LastProj = Instantiate(projFoudre, transform.position, Quaternion.Euler(0, 0, i * 90));
                    LastProj.direction = rotatedDirection;
                    LastProj.speed = 100;

                }
                health = 0;
            } ;break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerProjectile p;
        if (!other.TryGetComponent<PlayerProjectile>(out p)) return;
        get_touched_by(p.Myelement);
        Destroy(p.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0 )  Destroy(gameObject);
    }
}