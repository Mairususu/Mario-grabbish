using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] ennemis;
    [SerializeField] private float cooldown;
    [SerializeField] private float cooldownTimer;

    private bool canSpawn = true;

    private IEnumerator Spawn()
    {
        canSpawn = false;
        yield return new WaitForSeconds(cooldown);
        if (cooldown > 0.5) cooldown -= cooldownTimer;
        Instantiate(ennemis[Random.Range(0, ennemis.Length)], transform.position, Quaternion.identity);
        canSpawn = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (canSpawn) StartCoroutine(Spawn());
    }
}
