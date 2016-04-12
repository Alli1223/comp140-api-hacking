using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class deathPlanes : playerSave
{
	[SerializeField]
	private BoxCollider2D plane;
	[SerializeField]
	private GameObject saveTest;

	private Rigidbody2D rb;

	bool death;
	

	void Start ()
	{
		GetComponent<Rigidbody2D> ();
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.gameObject.tag == "Player") 
		{
			death = true;

			if(death == true)
			{
				LoadPos();
			}

		}

	}
	
}
