using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnnemyProjectile : MonoBehaviour  //Faudra rajouter le fait que ca se détruit etc, pour le moment ca se déplace uniquement
{

    [SerializeField] private GameObject direction;
    [SerializeField] private int projectileSpeed;
    
    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * projectileSpeed * direction.transform.forward;
    }
}
