using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public Vector3 direction;
    public enum Element{
        Fire,
        Water,
        Lightning,
        Nature
    }

    [SerializeField] private int speed;
    public Element Myelement;

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * speed * direction;
    }
    
}
