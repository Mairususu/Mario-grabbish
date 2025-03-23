using UnityEngine;

public class EnnemyProjectile : MonoBehaviour  //Faudra rajouter le fait que ca se détruit etc, pour le moment ca se déplace uniquement
{

    [SerializeField] public Vector3 direction;

    private MoveScriptPlayer move;
    public float projectileSpeed;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * projectileSpeed * direction;
    }
    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<MoveScriptPlayer>(out move)) move.ProjHit();
        Destroy(gameObject);
    }

}


