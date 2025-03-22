using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    enum Element{
        Fire,
        Water,
        Lightning,
        Nature
    }
	[SerializeField] private Sprite lightningPlayer;
	[SerializeField] private Sprite firePlayer;
	[SerializeField] private Sprite waterPlayer;
	[SerializeField] private Sprite naturePlayer;
    [SerializeField] private Element myElement;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private bool _canShoot = true;
    public float cooldown;
    
    public float cadence;
    public int numPlayer;

    private bool _canSwitch = true;
    
    [SerializeField] private GameObject projectileFeu; 
    [SerializeField] private GameObject projectileEau;
    [SerializeField] private GameObject projectileLightning;
    [SerializeField] private GameObject projectileNature;

    private IEnumerator Shoot(){
        _canShoot = false;
        if(myElement == Element.Fire) Instantiate(projectileFeu, transform.position, Quaternion.identity);
        if(myElement == Element.Water) Instantiate(projectileEau, transform.position, Quaternion.identity);
        if(myElement == Element.Lightning) Instantiate(projectileLightning, transform.position, Quaternion.identity);
        if(myElement == Element.Nature) Instantiate(projectileNature, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(cadence);
        _canShoot = true;
    }

    private void UpdateSprite(){
        if(myElement == Element.Fire){
            spriteRenderer.sprite = firePlayer;
        }
        if(myElement == Element.Lightning){
            spriteRenderer.sprite = lightningPlayer;
        }
        if(myElement == Element.Water){
            spriteRenderer.sprite = waterPlayer;
        }
        if(myElement == Element.Nature){
            spriteRenderer.sprite = naturePlayer;
        }
    }

    private IEnumerator Switch()
    {
        _canSwitch = false;
        if (myElement == Element.Fire) myElement = Element.Water;
        else if(myElement == Element.Water) myElement = Element.Fire;
        else if(myElement == Element.Nature) myElement = Element.Lightning;
        else if(myElement == Element.Lightning) myElement = Element.Nature;
        UpdateSprite();
        yield return new WaitForSeconds(cooldown);
        _canSwitch = true;
    }
    
    void Start()
    {
        UpdateSprite();        
    }

    // Update is called once per frame
    void Update()
    {
        if(numPlayer == 1 && Input.GetButtonDown("Fire1") && _canShoot){
            StartCoroutine(Shoot());
        }
        
        if(numPlayer == 2 && Input.GetButtonDown("Fire2") && _canShoot){
            StartCoroutine(Shoot());
        }

        if (Input.GetButtonDown("switch") && _canSwitch)
        {
            StartCoroutine(Switch());
        }
    }
}
