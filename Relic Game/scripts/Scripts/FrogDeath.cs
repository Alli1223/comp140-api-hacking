using UnityEngine;
using System.Collections;

public class FrogDeath : MonoBehaviour
{
	[SerializeField]
	private GameObject frog;
	//Set amount of barrels it takes to kill boss (25 damage = 4 barrels etc)
	[SerializeField]
	private float damage = 25f;

	private float health;

	void Start ()
	{
		float health = 100f;
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Barrel")
		{
			health -= damage;
		}
	}
	
	void Update ()
	{
		if(health <=0)
		{
			Destroy(frog);
		}
	}
}
