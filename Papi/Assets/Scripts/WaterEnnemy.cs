
using UnityEngine;


public class WaterEnnemy : ElementalEnnemies
{
    [SerializeField] public PlayerProjectile projFoudre;
        
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
            case PlayerProjectile.Element.Lightning:
            {
                Vector3 baseDirection = klass.get_direction_to(klass.cible);
                for (int i = 0; i < 4; i++)
                {
                    // Appliquer une rotation de 90° autour de l'axe Z
                    Vector3 rotatedDirection = Quaternion.Euler(0, 0, i * 90) * baseDirection;
        
                    // Instancier le projectile avec la rotation appropriée
                    PlayerProjectile LastProj = Instantiate(projFoudre, transform.position, Quaternion.Euler(0, 0, i * 90));
        
                    // Définir la direction et la vitesse du projectile
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