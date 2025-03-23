using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword_hitzone : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float attack_duration;

    public GameObject cible; 
    
    private Vector3 get_direction_to_(GameObject cible) // Permet d'obtenir la direction normalisé de n'importe quel Gameobject qu'on lui fournit
    {
        return (cible.transform.position - transform.position).normalized;
    }
    
    
    
    void Start()
    {
        
        StartCoroutine(coroutine(get_direction_to_(cible)));
    }
    
    private IEnumerator coroutine(Vector3 direct_cible)
    {
        yield return new WaitForSeconds(attack_duration);
        transform.up = direct_cible;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    
}
