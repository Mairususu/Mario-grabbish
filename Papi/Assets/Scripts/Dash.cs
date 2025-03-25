using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    
    [SerializeField] private float dash_duration; // Haut pr que ca fasse un dash
    [SerializeField] private float dash_threshold;
    [SerializeField] public Vector3 direction;
    [SerializeField] private float dash_cooldown;

    private float dash_speed;
    private bool canDash = true;


    [SerializeField] public KeyCode dashKey; // Permet de set quelle touche chaque joueur utilise pour dash
    
    
    
    private IEnumerator DashCoroutine()
    {
        canDash = false;
        dash_speed = dash_threshold;
        yield return new WaitForSeconds(dash_duration);
        dash_speed = 0;
        yield return new WaitForSeconds(dash_cooldown);
        canDash = true;

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(dashKey) && canDash)
        {
            StartCoroutine(DashCoroutine());
        }
        Debug.Log(dashKey);
        transform.position += Time.deltaTime * dash_speed * direction;
    }
}
