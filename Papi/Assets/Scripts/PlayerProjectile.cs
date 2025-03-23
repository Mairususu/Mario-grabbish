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

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private int speed;
    public Element Myelement;

    private void Start()
    {
        spriteRenderer.flipX = true;
    }


    // Update is called once per frame
    void Update()
    {
        if(direction == Vector3.zero) transform.position += Time.deltaTime * speed/4 * new Vector3(1,0,0);
        transform.position += Time.deltaTime * speed * direction.normalized/4;
        if (direction.normalized.x <= 0) spriteRenderer.flipX = false;
    }
    
}
