using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    private float _playedTime = 0;
    [SerializeField] private float inactiveTime;
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject[] ennemis;
    [SerializeField] private float cooldown;
    [SerializeField] private float cooldownTimer;

    public bool canSpawn = true;

    private IEnumerator Spawn()
    {
        canSpawn = false;
        Instantiate(ennemis[Random.Range(0, ennemis.Length)], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(cooldown);
        if (cooldown > 0.5) cooldown -= cooldownTimer;
        canSpawn = true;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (_playedTime <= inactiveTime) _playedTime += Time.deltaTime;
        if (canSpawn && inactiveTime <= _playedTime) StartCoroutine(Spawn());
    }
}
