using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour 
{
	//Which object will teleport (which will be the player)
	public GameObject player;
	//The position the player will be transforming to
	public Transform roomPos;


	// Use this for initialization
	void Start () 
	{

		}

	void Update ()
	{


	}

	void Awake ()
	{

	}
	
	// Update is called on trigger enter
	void OnTriggerEnter2D(Collider2D other) 
	{


		player.transform.position = roomPos.position;

}
}