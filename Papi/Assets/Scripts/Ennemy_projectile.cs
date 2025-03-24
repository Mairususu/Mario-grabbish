using UnityEngine;

public class EnnemyProjectile : AbstractProjectile  //Faudra rajouter le fait que ca se détruit etc, pour le moment ca se déplace uniquement
{
    private MoveScriptPlayer move;
   

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out move)) move.ProjHit();
        Destroy(gameObject);
    }

}


