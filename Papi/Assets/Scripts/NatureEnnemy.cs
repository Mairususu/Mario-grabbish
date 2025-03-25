using System.Collections.Generic;
using UnityEngine;


public class NatureEnnemy : ElementalEnnemies
{
    [SerializeField] private GameObject ennemyNature;
    [SerializeField] private AudioSource Source;
    [SerializeField] private List<AudioClip> projectileSound;
        
    private void get_touched_by(PlayerProjectile.Element elem)
    { 
        switch (elem)
        {
            case PlayerProjectile.Element.Water:
            {
                StartCoroutine(TakeHit(Color.yellow));
                Source.clip=projectileSound[0];
                Source.Play();
                health += 1  ;
                Instantiate(ennemyNature, transform.position + new Vector3(1.0f, 1.0f, 1.0f), Quaternion.identity);
            } break;
            case PlayerProjectile.Element.Fire:
                Source.clip=projectileSound[0];
                Source.Play();
                health = 0  ;
                break;
            case PlayerProjectile.Element.Nature :
                Source.clip=projectileSound[0];
                Source.Play();
                StartCoroutine(TakeHit(Color.red));
                health -= 1; break;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerProjectile p;
        if (!other.TryGetComponent(out p)) return;
        get_touched_by(p.Myelement);
        Destroy(p.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0 )  Destroy(gameObject);
    }
}