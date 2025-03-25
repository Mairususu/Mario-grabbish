using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerNumber { Player1, Player2 }

public class MoveScriptPlayer : MonoBehaviour // svp plus jamais les mouvements des 2 joueurs en un script, worst idea T.T
{

	[SerializeField] Rigidbody2D rb;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private HPSystem hpSystem; 
	
	private Dash dash; 
	public static MoveScriptPlayer instanceP1;
	public static MoveScriptPlayer instanceP2;
	
    public PlayerNumber numJoueur;
	public float moveSpeed;
	public float horizontalMovement;
	public float verticalMovement;
	private bool imune = false;
	private Vector3 deplacement;
	
	public void ProjHit()
	{
		if (!imune) StartCoroutine(TakeHit());
	}

	private void OnCollisionStay(Collision other) // ici je rajoute le fait que ce soit un projectile ennemy car je vais réactiver les collisions entre joueurs et collisions
	{
		if (other.gameObject.layer == 9) // Pour qu'il prenne des dégats uniqument avec les projectiles ennemis
			StartCoroutine(TakeHit());
	}

	private IEnumerator TakeHit()
	{
		imune = true;
		hpSystem.Coll();
		for (int i = 0; i < 3; i++) {
			spriteRenderer.color = Color.red;
			yield return new WaitForSeconds(0.2f);
			spriteRenderer.color = Color.white;
			yield return new WaitForSeconds(0.2f);
		}
		imune = false;
	}

	private void Awake()
	{
		dash  = GetComponent<Dash>();
		if (numJoueur == PlayerNumber.Player1) dash.dashKey = KeyCode.Keypad0;
		if (numJoueur == PlayerNumber.Player2) dash.dashKey = KeyCode.C;    
		
		if (numJoueur == PlayerNumber.Player1)
		{
			if (instanceP1 != null) Destroy(gameObject);
			else instanceP1 = this;
		}
		else
		{
			if (instanceP2 != null) Destroy(gameObject);
			else instanceP2 = this;
		}
	}

	void Update(){
		if (numJoueur == PlayerNumber.Player1)
		{
			horizontalMovement = Input.GetAxis("Horizontal_Player1");
			verticalMovement = Input.GetAxis("Vertical_Player1");
		}
		if (numJoueur == PlayerNumber.Player2)
		{
			horizontalMovement = Input.GetAxis("Horizontal_Player2") ;
			verticalMovement = Input.GetAxis("Vertical_Player2");
		}
		
		
		deplacement = new Vector3(horizontalMovement, verticalMovement,0).normalized;
		transform.position += deplacement * (Time.deltaTime * moveSpeed);
		
		if (horizontalMovement > 0) spriteRenderer.flipX = true;
		else spriteRenderer.flipX = false;
		dash.direction = deplacement;
	}
}

