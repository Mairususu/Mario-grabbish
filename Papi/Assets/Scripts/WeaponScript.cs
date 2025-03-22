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
    public float cadence;
    
    [SerializeField] private GameObject projectile; 

    private IEnumerator Shoot(){
        canShoot = false;
        Instantiate(projectile, transform.position, transform.rotation);
        yield return new WaitForSeconds(cadence);
        canShoot = true;
    }

    private void UpdateSprite(){
        if(myElement == Element.fire){
            spriteRenderer.sprite = FirePlayer;
        }
        if(myElement == Element.lightning){
            spriteRenderer.sprite = LightningPlayer;
        }
        if(myElement == Element.water){
            spriteRenderer.sprite = WaterPlayer;
        }
        if(myElement == Element.nature){
            spriteRenderer.sprite = NaturePlayer;
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
