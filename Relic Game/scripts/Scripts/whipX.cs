using UnityEngine;
using System.Collections;

public class whipX : MonoBehaviour
{

	[SerializeField]
	private LayerMask mask;
	[SerializeField]
	private float step = 0.02f;
	[SerializeField]
	private LineRenderer whipLine;
	[SerializeField]
	private float whipDelay = 2f;
	[SerializeField]
	private float maxDistance = 1f;
	[SerializeField]
	private float pullDelay = 1f;
	[SerializeField]
	private GameObject whip;

	
	private Transform targetLocation;
	private float restScale;
	private float targetScale;
	private Vector3 whipPoint;
	private DistanceJoint2D joint;
	private RaycastHit2D hit;
	private Transform raycastObject;
	private Animator anim;
	private GameObject player;
	private bool inDelay;
	

	[SerializeField]
	private States currentState;
	enum States
	{
		Rest,
		Delay,
		TeleportPlayer,
		PullObject
	}

	void Start ()
	{
		currentState = States.Rest;
		joint = GetComponent<DistanceJoint2D> ();
		anim = GetComponent<Animator> ();
		whipLine.enabled = false;
		joint.enabled = false;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void Update ()
	{
		switch (currentState) 
		{
		case States.Rest:
			DisableWhip();
			break;
		case States.Delay:
			DelayWhip();
			break;
		case States.TeleportPlayer:
			TeleportPlayer();
			break;
		case States.PullObject:
			PullObject();
			break;
		}

		if (Input.GetMouseButtonUp(0)) 
		{
			currentState = States.Rest;
		}

		if (Input.GetMouseButton(1))
		{
			StartCoroutine ("PullObject");
		}

		if (Input.GetMouseButtonDown(0))
		{
			if (!inDelay)
			{
				Debug.Log ("Mouse click pressed");
				currentState = States.TeleportPlayer;
				StartCoroutine(TeleportPlayer());
			}
		}

		joint.distance = Vector2.Distance (transform.position, whipPoint);
		joint.distance -= step;

	}

	void DisableWhip ()
	{
		//Revert to normal operation

		joint.enabled = false;
		whipLine.enabled = false;
		anim.SetBool ("attacking", false);
	}
	
	IEnumerator DelayWhip ()
	{
		inDelay = true;
		//spawn coiled whip
		Debug.Log ("rest init");
		yield return new WaitForSeconds (whipDelay);
		//currentState = States.TeleportPlayer;

		StopCoroutine ("DelayWhip");
		inDelay = false;
		currentState = States.Rest;
		//play animation to simulate moving whip
	}

	/*Get the location of the players mouse click
	spawn coiled whip when button is pressed
	play animation and extend the animated whip
	teleport player to location*/

	IEnumerator TeleportPlayer ()
	{
		//Prevents player from holding down to infinitely teleport
		if (Input.GetMouseButton(0))
		{
			yield return null;
		}

		whipPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		//Prevents teleporting over massive distances
		if (joint.distance > maxDistance)
		{
			yield return null;
		}

		hit = Physics2D.Raycast (transform.position, whipPoint - transform.position, joint.distance, mask);

		if (hit.collider != null) 
		{
			if (hit.collider.tag == "Pull Colliders")

			{
				anim.SetBool ("attacking", true);
				whip.transform.rotation = Quaternion.LookRotation(Vector3.forward, whipPoint - transform.position);
				Instantiate(whip, player.transform.position, whip.transform.rotation);
				joint.enabled = true;
				joint.connectedAnchor = whipPoint;
				//The delay here is needed to fix the "lock in place" bug
				currentState = States.Delay;
				StartCoroutine(DelayWhip());
			}
			else
			{
				Debug.Log ("pull collider not found");
				//currentState = States.Delay;
				yield return null;
			}

//			if (Input.GetMouseButtonUp(0))
//			{
//				joint.enabled = false;
//				currentState = States.Rest;
//			}

		}
		Debug.Log("delay init");
		anim.SetBool ("attacking", false);
		yield return new WaitForSeconds (whipDelay);
		currentState = States.Rest;
			
	}

	/*press mouse button to fire raycast
	if object has a collider
	add component distance joint and rigid body
	move the object to the player and parent the object
	mouse wheel to pull object towards player
	configure break force depending on mass of object (or button to release)*/

	IEnumerator PullObject ()
	{
		float pullSpeed = 0.01f;
		step = pullSpeed * Time.fixedDeltaTime;

		if (Input.GetMouseButtonUp (1)) 
		{
			yield return null;
			StopCoroutine ("PullObject");
			currentState = States.Rest;
        }

			whipPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			hit = Physics2D.Raycast (transform.position, whipPoint - transform.position, joint.distance, mask);

		while (Input.GetMouseButton(1))//GetComponent<Rigidbody2D>()!=null)//(hit.collider!=null) 
		{

			if (hit.collider.tag == "Grabbable Colliders")
			{
				yield return new WaitForSeconds (pullDelay);

				Transform parentObject;
				parentObject = GameObject.FindGameObjectWithTag("Player").transform;
				GameObject objectsRigidBody;

				joint.enabled = true;
				joint.connectedAnchor = whipPoint;
				joint.connectedBody = hit.collider.GetComponent<Rigidbody2D>();
				joint.connectedBody = hit.collider.gameObject.AddComponent<Rigidbody2D>();

				raycastObject = hit.collider.transform;
				raycastObject.parent = parentObject;
				raycastObject.transform.position = Vector2.MoveTowards(hit.point, transform.position, step);
				//raycastObject.transform.position = transform.position;

				Destroy (raycastObject.GetComponent<Rigidbody2D>());
				joint.connectedBody = null;
				raycastObject.parent = null;
				DisableWhip();
				joint.distance = Vector2.Distance(hit.point,transform.position);
				yield break;
			}
			else
			{
				yield break;
			}

		}

		currentState = States.Rest;
	}

	//- new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
	
}


	

