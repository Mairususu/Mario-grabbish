using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerNumber
{
	Player1,
	Player2
}

public class MoveScriptPlayer : MonoBehaviour
{
	public static MoveScriptPlayer instanceP1;
	public static MoveScriptPlayer instanceP2;
	
	[SerializeField] Rigidbody2D rb;
    public PlayerNumber numJoueur;
	public float moveSpeed;
	public float horizontalMovement;
	public float verticalMovement;
	[SerializeField] private SpriteRenderer spriteRenderer;
	private bool imune = false;
	[SerializeField] private HPSystem hpSystem;
	
	IEnumerator TakeHit()
	{
		imune = true;
		hpSystem.Coll();
		spriteRenderer.color = Color.red;
		yield return new WaitForSeconds(0.2f);
		spriteRenderer.color = Color.white;
		yield return new WaitForSeconds(0.2f);
		spriteRenderer.color = Color.red;
		yield return new WaitForSeconds(0.2f);
		spriteRenderer.color = Color.white;
		yield return new WaitForSeconds(0.2f);
		spriteRenderer.color = Color.red;
		yield return new WaitForSeconds(0.2f);
		spriteRenderer.color = Color.white;
		imune = false;
	}
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (!imune) StartCoroutine(TakeHit());
	}

	private void Awake()
	{
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
		if (numJoueur == PlayerNumber.Player1){
			horizontalMovement = Input.GetAxis("Horizontal_Player1") * moveSpeed * Time.deltaTime;
			verticalMovement = Input.GetAxis("Vertical_Player1") * moveSpeed * Time.deltaTime;}
		if (numJoueur == PlayerNumber.Player2){
			horizontalMovement = Input.GetAxis("Horizontal_Player2") * moveSpeed * Time.deltaTime;
			verticalMovement = Input.GetAxis("Vertical_Player2") * moveSpeed * Time.deltaTime;}

		if (horizontalMovement > 0) spriteRenderer.flipX = true;
		else spriteRenderer.flipX = false;
	
		transform.position += new Vector3(horizontalMovement, verticalMovement,0);
	}
}
