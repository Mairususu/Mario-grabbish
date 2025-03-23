using UnityEngine;


public class LightningEnnemy : ElementalEnnemies
{
        
    private void get_touched_by(PlayerProjectile.Element elem)
    { 
        switch (elem)
        {
            case PlayerProjectile.Element.Nature:
            {
                health = 0;
            } break;
            case PlayerProjectile.Element.Fire:
            {
                health -= 1  ;break;
            }
            case PlayerProjectile.Element.Lightning :
                health -= 1;
                for (int i = 0; i < 4; i++)
                {
                    transform.position += 3 * klass.get_direction_to(klass.cible);
                } break;
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
    // Update is called once per frame
    void Update()
    {
        if (health == 0 )  Destroy(gameObject);
    }
}