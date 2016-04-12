using UnityEngine;
using System.Collections;

public class musicPlay : MonoBehaviour
{


	//public Transform jukeBox;
	public AudioSource music;
	public float fade = 0.1f;

	private float audioVolume;


	// Use this for initialization
	void Start ()
	{
		music = GetComponent<AudioSource> ();
		//music.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

	}
	//When the player enters the trigger, it plays music.
	void OnTriggerEnter2D (Collider2D other)
	{
		fadeIn();
		if (other.tag == "Player") {
			music.enabled = true;
			music.Play();

		}
	}
	//When the player leaves the trigger, it stops the music
	void OnTriggerExit2D (Collider2D other)
	{
		fadeOut();
		music.enabled = false;
		music.Pause ();
	}

	void fadeIn() 
	{

	}

	void fadeOut ()
	{

	}
}

