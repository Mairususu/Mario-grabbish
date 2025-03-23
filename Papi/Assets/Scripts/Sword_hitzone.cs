using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;


public class Sword_hitzone : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float attack_duration;
    private MoveScriptPlayer move;

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
        transform.right = direct_cible;
        yield return new WaitForSeconds(attack_duration);
        Destroy(gameObject);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.TryGetComponent<MoveScriptPlayer>(out move)) move.ProjHit();
    }
    
}
