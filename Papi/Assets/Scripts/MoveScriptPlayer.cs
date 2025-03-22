using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptPlayer : MonoBehaviour
{
	public int horizontal = 0;
	public int vertical = 0;
	public Vector3 direction;
    public int numJoueur;
	public float moveSpeed;
	private float horizontalMovement;
	private float verticalMovement;
	public Vector3 velocity = Vector3.zero;
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
		
		if(horizontalMovement > 0) horizontal = 1;
		else if(horizontalMovement < 0) horizontal = -1;
		else horizontal = 0;
		
		if(verticalMovement > 0) vertical = 1;
		else if(verticalMovement < 0) vertical = -1;
		else vertical = 0;
		
		direction = new Vector3(horizontal, vertical, 0);
		
		transform.position += new Vector3(horizontalMovement, verticalMovement,0);
	}
}
