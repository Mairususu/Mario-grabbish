using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{

    public enum type { Fire = 1, Nature = 2, Thunder = 3, Water = 4 };  
    // j'inscris les deux là, je fais un constructeur qui permet de leur attribuer à leur création, puis je leur attache le gameobject qu'il faut en fonction de leur type
    
    public enum klass { Melee = 1, Archer = 2 };


    [SerializeField] public int pv;
    [SerializeField] public int speed;
    [SerializeField] public int damage;
    [SerializeField] public type element;
    [SerializeField] public klass comportement;


    public Ennemy(klass k, element e)
    {
        
    }
    
    
    protected void death(){
        if (element != type.Fire)
        {
            Destroy(GameObject);
        }
    }
    
    
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
