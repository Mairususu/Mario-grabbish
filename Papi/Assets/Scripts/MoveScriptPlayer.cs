using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptPlayer : MonoBehaviour
{
	[SerializeField] Rigidbody2D rb;
    public int numJoueur;
	public float moveSpeed;
	public float horizontalMovement;
	public float verticalMovement;
	[SerializeField] private SpriteRenderer spriteRenderer;
	
	void Update(){
		if (numJoueur == 1){
			horizontalMovement = Input.GetAxis("Horizontal_Player1") * moveSpeed * Time.deltaTime;
			verticalMovement = Input.GetAxis("Vertical_Player1") * moveSpeed * Time.deltaTime;}
		if (numJoueur == 2){
			horizontalMovement = Input.GetAxis("Horizontal_Player2") * moveSpeed * Time.deltaTime;
			verticalMovement = Input.GetAxis("Vertical_Player2") * moveSpeed * Time.deltaTime;}

		if (horizontalMovement > 0) spriteRenderer.flipX = true;
		else spriteRenderer.flipX = false;
		
		transform.position += new Vector3(horizontalMovement, verticalMovement,0);
	}
}
