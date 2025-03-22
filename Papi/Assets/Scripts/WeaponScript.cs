using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    enum Element{
        fire,
        water,
        lightning,
        nature
    }
	[SerializeField] private Sprite LightningPlayer;
	[SerializeField] private Sprite FirePlayer;
	[SerializeField] private Sprite WaterPlayer;
	[SerializeField] private Sprite NaturePlayer;
    [SerializeField] private Element myElement;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool canShoot = true;
    public float cadance;
    
    [SerializeField] private GameObject projectile; 

    private IEnumerator Shoot(){
        canShoot = false;
        Instantiate(projectile, transform.position, transform.rotation);
        yield return new WaitForSecond(cadance); 
        canShoot = true;
    }

    private void UpdateSprite(){
        if(myElement == fire){
            spriteRenderer.Sprite = FirePlayer;
        }
        if(myElement == lightning){
            spriteRenderer.Sprite = LightningPlayer;
        }
        if(myElement == water){
            spriteRenderer.Sprite = WaterPlayer;
        }
        if(myElement == nature){
            spriteRenderer.Sprite = NaturePlayer;
        }
    }

    void Start()
    {
        UpdateSprite();        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canShoot){
            StartCoroutine(Shoot());
        }
    }
}
