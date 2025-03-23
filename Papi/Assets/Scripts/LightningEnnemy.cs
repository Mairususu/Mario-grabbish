using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;


public class LightningEnnemy : ElementalEnnemies
{
    [SerializeField] private float dash_duration; // Haut pr que ca fasse un dash
    [SerializeField] private float dash_threshold;
    
    private float dash_speed;


    private IEnumerator dashCoroutine()
    {
        dash_speed = dash_threshold;
        yield return new WaitForSeconds(dash_duration);
        dash_speed = 0;
    }

    public class ArcherEnnemy : Ennemy
    {
    }
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
                    StartCoroutine(dashCoroutine());
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
        transform.position += klass.get_direction_to(klass.cible) * (float)(Time.deltaTime * dash_speed);
        if (health == 0 )  Destroy(gameObject);
    }
}