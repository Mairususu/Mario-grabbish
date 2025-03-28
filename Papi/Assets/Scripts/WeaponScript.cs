using System.Collections;
using UnityEngine;


public class WeaponScript : MonoBehaviour
{
    enum Element
    {
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
    private PlayerProjectile projectile;

    private bool _canShoot = true;
    public float cooldown;

    [SerializeField] private float cadence;
    public int numPlayer;

    private bool _canSwitch = true;

    [SerializeField] private PlayerProjectile projectileFire;
    [SerializeField] private PlayerProjectile projectileWater;
    [SerializeField] private PlayerProjectile projectileLightning;
    [SerializeField] private PlayerProjectile projectileNature;
    [SerializeField] private AudioSource shootSFX;
    [SerializeField] private AudioSource switchSFX;
    private bool J1shoot = false;
    private bool J2shoot = false;

    private IEnumerator Shoot()
    {
        PlayerProjectile projectileFuture;
        _canShoot = false;
        shootSFX.Play();
        switch (myElement)
        {
            case Element.Fire : projectileFuture = projectileFire; break;
            case Element.Water : projectileFuture = projectileWater; break; 
            case Element.Lightning : projectileFuture = projectileLightning; break; 
            default : projectileFuture = projectileNature; break;
        }
        Vector3 directionproj = Vector3.zero;
        if ((Input.GetKeyDown(KeyCode.T) ) || (Input.GetKeyDown(KeyCode.UpArrow)) ) directionproj += new Vector3(0f , 1f , 0f);            // Ca va être un peu moche mais bon
        if ((Input.GetKeyDown(KeyCode.F) ) || (Input.GetKeyDown(KeyCode.LeftArrow)) ) directionproj += new Vector3(-1f , 0f , 0f);            // Ca va être un peu moche mais bon
        if ((Input.GetKeyDown(KeyCode.G) ) || (Input.GetKeyDown(KeyCode.DownArrow)) ) directionproj += new Vector3(0f , -1f , 0f);            // Ca va être un peu moche mais bon
        if ((Input.GetKeyDown(KeyCode.H) ) || (Input.GetKeyDown(KeyCode.RightArrow)) ) directionproj += new Vector3(1f , 0f , 0f);            // Ca va être un peu moche mais bon
        
        PlayerProjectile lastProj = Instantiate(projectileFuture, transform.position, Quaternion.identity);
        lastProj.direction = directionproj.normalized;
        yield return new WaitForSeconds(cadence);
        _canShoot = true;
    }

    private void UpdateSprite()
    {
        if (myElement == Element.Fire)
        {
            spriteRenderer.sprite = firePlayer;
        }

        if (myElement == Element.Lightning)
        {
            spriteRenderer.sprite = lightningPlayer;
        }

        if (myElement == Element.Water)
        {
            spriteRenderer.sprite = waterPlayer;
        }

        if (myElement == Element.Nature)
        {
            spriteRenderer.sprite = naturePlayer;
        }
    }

    private IEnumerator Switch()
    {
        _canSwitch = false;
        switchSFX.Play();
        if (myElement == Element.Fire) myElement = Element.Water;
        else if (myElement == Element.Water) myElement = Element.Fire;
        else if (myElement == Element.Nature) myElement = Element.Lightning;
        else if (myElement == Element.Lightning) myElement = Element.Nature;
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
        if (Input.GetKeyDown(KeyCode.T) || Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.H) || Input.GetKeyDown(KeyCode.F)) J2shoot = true;
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.DownArrow)) J1shoot = true;
        
        if(numPlayer == 1 && J1shoot && _canShoot){
            StartCoroutine(Shoot());
        }
        
        if(numPlayer == 2 && J2shoot && _canShoot){
            StartCoroutine(Shoot());
        }

        if (Input.GetButtonDown("switch") && _canSwitch)
        {
            StartCoroutine(Switch());
        }

        J1shoot = false;
        J2shoot = false;
    }
}
