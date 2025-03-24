using UnityEngine;


public class NatureEnnemy : ElementalEnnemies
{
    [SerializeField] private GameObject ennemyNature;
        
    private void get_touched_by(PlayerProjectile.Element elem)
    { 
        switch (elem)
        {
            case PlayerProjectile.Element.Water:
            {
                StartCoroutine(TakeHit(Color.yellow));
                health += 1  ;
                Instantiate(ennemyNature, transform.position + new Vector3(1.0f, 1.0f, 1.0f), Quaternion.identity);
            } break;
            case PlayerProjectile.Element.Fire:
                health = 0  ;
                break;
            case PlayerProjectile.Element.Nature :
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