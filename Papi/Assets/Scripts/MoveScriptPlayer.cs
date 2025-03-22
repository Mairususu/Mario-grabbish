using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptPlayer : MonoBehaviour
{
    public int numJoueur;
	public float moveSpeed;
	private float horizontalMovement;
	private float verticalMovement;
	public Vector3 velocity = Vector3.zero;

	void Update(){
		if (numJoueur == 1){
			horizontalMovement = Input.GetAxis("Horizontal_Player1") * moveSpeed * Time.deltaTime;
			verticalMovement = Input.GetAxis("Vertical_Player1") * moveSpeed * Time.deltaTime;}
		if (numJoueur == 2){
			horizontalMovement = Input.GetAxis("Horizontal_Player2") * moveSpeed * Time.deltaTime;
			verticalMovement = Input.GetAxis("Vertical_Player2") * moveSpeed * Time.deltaTime;}

		transform.position += new Vector3(horizontalMovement, verticalMovement,0);
	}
}
