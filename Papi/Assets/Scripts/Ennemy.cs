using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{

    
    [SerializeField] public int pv;
    [SerializeField] public int speed;
    [SerializeField] public int damage;
    [SerializeField] public GameObject element;
    [SerializeField] public GameObject klass;



/*    protected void death(){
        if (element != type.Fire)
        {
            Destroy(GameObject);
        }
    }
*/    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
