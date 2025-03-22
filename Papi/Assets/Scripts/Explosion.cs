using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // EXPLOSSIOOOOOOOOOOOOOOOOOOONNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoroutineExplosion());
    }


    private void OnTriggerEnter2D(Collider2D other) // à remplir c'est ce qui va permettre de faire des degats durant l'explosion
    {

    }

    private IEnumerator CoroutineExplosion()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
