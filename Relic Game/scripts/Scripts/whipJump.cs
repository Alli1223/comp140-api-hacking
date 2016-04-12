using UnityEngine;
using System.Collections;

public class whipJump : MonoBehaviour
{

	[SerializeField]
	private int immuneTimer = 3;
	[SerializeField]
	private GameObject player;
	[SerializeField]
	private BoxCollider2D box;
	private Rigidbody2D rb;
	private WrapMode wrap;

	
	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
		box = GetComponent<BoxCollider2D> ();
		GameObject playerCharacter = GameObject.Find("Player");
	}
	

	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			box.enabled = false;
			//play ascending animation
			//animation.wrap = WrapMode.Once;
			//animation.Play("AnimationName");
			//Immune();
			//call slow function from character script
			Debug.Log ("speed reduced");
			GetComponent<characterController>().speed = 12f;
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			box.enabled = true;
			//play descending animation
			//animation.wrap = WrapMode.Once;
			//animation.Play("AnimationName");
			//revert to normal speed
			GetComponent<characterController>().speed = 20f;
		}

	}

//	void Immune ()
//	{
//		box.enabled = false;
//		// disable collider for a certain amount of seconds
//		DelayTimer ();
//		StartCoroutine ("DelayTimer");
//		// re-enable collider
//	}

	IEnumerator DelayTimer()
	{
		yield return new WaitForSeconds (immuneTimer);
		StopCoroutine ("DelayTimer");
	}
}
