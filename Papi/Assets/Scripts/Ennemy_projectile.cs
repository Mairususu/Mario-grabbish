using UnityEngine;

public class EnnemyProjectile : MonoBehaviour  //Faudra rajouter le fait que ca se détruit etc, pour le moment ca se déplace uniquement
{

    [SerializeField] public Vector3 direction;
    
    public float projectileSpeed;
    
    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * projectileSpeed * direction;
    }
}
