using UnityEngine;
using System.Collections;

public class playerSave : MonoBehaviour
{

	public Transform player;


	public float playerX;

	public float playerY;

	private Vector3 currentPos;
	

	void Start ()
	{
		PlayerPrefs.DeleteAll();
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.transform.tag == "Player") 
		{
			playerX = player.transform.position.x;
			PlayerPrefs.SetFloat("x", playerX);
			
			playerY = player.transform.position.y;
			PlayerPrefs.SetFloat("y", playerY);

			//if player walks into trigger, update playerprefs
			//in death script if player dies loads current pos
		}

	}

	public void LoadPos ()
	{

		if (PlayerPrefs.HasKey ("x") && PlayerPrefs.HasKey ("y")) 
		{
			PlayerPrefs.GetFloat ("x", playerX);
					
			PlayerPrefs.GetFloat ("y", playerY);
		
			Vector3 currentPos = new Vector2 (PlayerPrefs.GetFloat("x"),PlayerPrefs.GetFloat("y"));
			player.transform.position = currentPos;
		}

		PlayerPrefs.DeleteAll ();

	}
	
}
