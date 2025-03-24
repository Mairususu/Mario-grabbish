using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractProjectile : MonoBehaviour
{
    
    [SerializeField] public float speed;
    
    public Vector3 direction;
    // Start is called before the first frame update
    
    private void Start()
    {
        transform.right = direction;
    }


    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * speed * direction;
    }
}
