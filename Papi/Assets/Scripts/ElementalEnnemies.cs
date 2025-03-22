using UnityEngine;

public class ElementalEnnemies : MonoBehaviour  // classe abstraite pour les elements
{
    [SerializeField] public Ennemy klass; // On le remplit quand on invoque le mob
    [SerializeField] public int health;
    [SerializeField] public int damage;
}
    