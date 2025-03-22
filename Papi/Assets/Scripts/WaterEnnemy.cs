
using UnityEngine;


public class WaterEnnemy : ElementalEnnemies
{
        [SerializeField] private GameObject projFoudre;
        
    private void get_touched_by(PlayerProjectile.Element elem)
    { 
        switch (elem)
        {
            case PlayerProjectile.Element.Nature:
            {
                health -= 1;
                transform.localScale *= 0.6f;
                klass.speed *= 1.5f;
            } break;
            case PlayerProjectile.Element.Water:
                health -= 1  ;break;
            case PlayerProjectile.Element.Lightning :
                health = 0;
                for (int i = 0; i < 4; i++)
                {
                    Instantiate(projFoudre, transform.position, Quaternion.Euler(0, 0, i * 90));
                } break;
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