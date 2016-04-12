using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour
{

	public Rigidbody2D rb;

	//private KeyCode horizontal;
	//private KeyCode vertical;

	public float speed = 100f;
	private float forwardMovement;
	private float sideMovement;
	private Animator animator;
	private Vector2 lastMove;
	private bool freezeMovement;


	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator>();
	}
	
	void Update ()
	{
		animator.SetBool ("walking", false);
		if (!freezeMovement) {
			GetInput ();
			CharacterMove ();
		}
		else{
			rb.velocity = Vector3.zero;
			}
		}

	void FixedUpdate ()
	{
		//CharacterMove();
	}

	void GetInput ()
	{

		forwardMovement = Input.GetAxisRaw("Vertical") * speed;
		sideMovement = Input.GetAxisRaw("Horizontal") * speed;

		animator.SetFloat ("SpeedX", sideMovement);
		animator.SetFloat ("SpeedY", forwardMovement);

		Vector3 moveHorizontal = transform.right * sideMovement;
		Vector3 moveVertical = transform.forward * forwardMovement;

	
	}

	void CharacterMove ()
	{


		//if (Input.GetKeyDown(horizontal))
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
		{
			rb.AddForce(new Vector2 (sideMovement, 0f) * Time.fixedDeltaTime * speed);
			animator.SetBool ("walking", true);
			lastMove = new Vector2 (sideMovement, 0f);
		}

		//if (Input.GetKeyDown(vertical))
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
		{
			rb.AddForce(new Vector2 (0f, forwardMovement) * Time.fixedDeltaTime * speed);
			animator.SetBool ("walking", true);
			lastMove = new Vector2 (0f, forwardMovement);
		}

		animator.SetFloat ("LastMoveX", lastMove.x);
		animator.SetFloat ("LastMoveY", lastMove.y);
			
	}

	void FreezeMovement ()
	{
		freezeMovement = true;
	}

	void UnFreezeMovement()
	{
		freezeMovement = false;
	}
	
}
