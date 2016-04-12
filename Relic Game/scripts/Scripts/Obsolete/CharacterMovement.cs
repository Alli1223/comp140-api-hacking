using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public float speed = 5.2f;
	public float gravity = -10f;
	public float JumpStrength = 3f;
	public float turnSpeed = 180f;
	CharacterController character;
	Vector3 movement;

	// Use this for initialization
	void Start () {
		character = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetKeyDown (KeyCode.Space) && character.isGrounded) {
			movement.y = JumpStrength;
		}
		float turnAmount = Input.GetAxis ("Horizontal");

		movement.x = Input.GetAxis ("Horizontal");
		movement.y = Input.GetAxis ("Vertical");

		 


		character.Move (movement * speed * Time.deltaTime);
	}
}