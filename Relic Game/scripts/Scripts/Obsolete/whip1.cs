using UnityEngine;
using System.Collections;

public class whip1: MonoBehaviour
{

	/*Get the location of the players mouse click
	spawn coiled whip when button is pressed
	play animation and extend the animated whip
	find location of latched object
	latch onto objects (not environment yet)
	press other button to pull object towards the player*/

	//public GameObject whipObject;
	//public Transform objectLocation;
	[SerializeField]
	public LayerMask mask;
	[SerializeField]
	public float step = 0.02f;
	[SerializeField]
	public LineRenderer whipLine;

	private Transform targetLocation;
	private float restScale;
	private float targetScale;
	//private Vector3 whipOffset;
	private Vector3 whipPoint;
	private DistanceJoint2D joint;
	private RaycastHit2D hit;
	private float distance = 10f;

	[SerializeField]
	private States currentState;
	enum States
	{
		Static,
		GetObject,
		PullObject
	}

	void Start ()
	{
		currentState = States.Static;
		joint = GetComponent<DistanceJoint2D> ();
		whipLine.enabled = false;
		joint.enabled = false;
	}
	

	void Update ()
	{
		switch (currentState) 
		{
			case States.Static:
			StaticWhip();
			break;
			case States.GetObject:
			GetObject();
			break;
//			case States.PullObject:
//			PullObject();
//			break;
		}

	}

	void StaticWhip ()
	{

		if (joint.distance > .5f) 
		{	
			joint.distance -= step;
		}
		else
		{
			joint.enabled = false;
		}

		if (Input.GetMouseButtonDown(0))
		{
			//spawn coiled whip
			//whipObject.SetActive(true);
	
			currentState = States.GetObject;

			//play animation to simulate moving whip
		}

	}

	void GetObject ()
	{

		whipPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		whipPoint.z = 0f;


		//joint = gameObject.AddComponent <DistanceJoint2D> ();

		hit = Physics2D.Raycast (transform.position, whipPoint - transform.position, distance, mask);

		if (hit.collider != null)
		    //&& hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
		{
			joint.enabled = true;
			joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
			joint.distance = Vector2.Distance (transform.position, hit.point);
			joint.connectedAnchor = whipPoint; //- new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);

			whipLine.enabled = true;
			whipLine.SetPosition(0,transform.position);
			whipLine.SetPosition(1, whipPoint);
		}

		if (Input.GetMouseButton(0))
		{
			whipLine.SetPosition(0,transform.position);
			whipLine.enabled = true;
		}

		if (Input.GetMouseButtonUp(0))
		{
			joint.enabled = false;
			whipLine.enabled = false;
			joint.connectedBody = null;
			currentState = States.Static;
		}


//		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//
//		if (Physics.Raycast (ray, out hit)) 
//		{
//			transform.LookAt(hit.point);
//			whipPoint = hit.point;
//
//			float whipToWhipEnd = Vector3.Distance(transform.position, objectLocation.position);
//			float whipToTarget = Vector3.Distance(transform.position, hit.point);
//
//			targetScale = restScale * whipToTarget / whipToWhipEnd;
//			objectLocation = hit.transform;
//		
//		}
//
//		Vector3 scale = transform.localScale;
//		scale.z *= 1.1f;
//		transform.localScale = scale;
//		
//		if (transform.localScale.z > targetScale) 
//		{
//			scale = transform.localScale;
//			scale.z = targetScale;
//			transform.localScale = scale;
//			
//			whipOffset = objectLocation.position - targetLocation.position;
//			currentState = States.PullObject;
//		}

	}

//	void PullObject ()
//	{
//		//pull objects transform to players
//		Vector3 scale = transform.localScale;
//		scale.z *= 0.9f;
//		transform.localScale = scale;
//		targetLocation.position = objectLocation.position + whipOffset;
//		
//		if (transform.localScale.z < restScale) 
//		{
//			scale = transform.localScale;
//			scale.z = restScale;
//			transform.localScale = scale;
//			currentState = States.Static;
//		}
//
//	}
	
}
