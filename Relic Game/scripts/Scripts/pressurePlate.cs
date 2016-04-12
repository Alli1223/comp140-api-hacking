using UnityEngine;
using System.Collections;

public class pressurePlate : MonoBehaviour
{
	
	[SerializeField]
	private Collider2D Barrel;
    [SerializeField]
    private GameObject doors;
    private GameObject player;

			
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Grabbable Colliders")
		{
			//Door open animation
            doors.SetActive (false);
			Debug.Log("door opened");
			//disable door colliders
		}

	}

	void OnTriggerExit2D (Collider2D other)
	{
		//Door closes animation
		if(other.gameObject.tag == null)
		{
			doors.SetActive(true);
		}
		//enable door colliders
		
	}


}
