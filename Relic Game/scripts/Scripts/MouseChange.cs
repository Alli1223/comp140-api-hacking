using UnityEngine;
using System.Collections;

public class MouseChange : MonoBehaviour
{

	//check for mouse cursor
	//if mouse cursor connects with tag "grabbable colliders"
	//run overlay function
	
	[SerializeField]
	private Texture2D cursorTexture;
	
	private GameObject go;
	

	RaycastHit2D hit;
	
	
	void OnMouseEnter ()
	{
		CursorMode cursorMode = CursorMode.Auto;
		Vector2 hotSpot = Vector2.zero;

		Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		hit = Physics2D.Raycast(worldPoint,Vector2.zero);


		if (hit.collider != null) 
		{
			if (hit.collider.tag == "Grabbable Colliders") 
			{
				Debug.Log ("this");
				//Debug.DrawRay(Input.mousePosition,forward
				Cursor.SetCursor (cursorTexture, hotSpot, cursorMode);
			}
		}

	}
	

	void OnMouseExit ()
	{
		Debug.Log ("not null");
		CursorMode cursorMode = CursorMode.Auto;
		
		Vector2 hotSpot = Vector2.zero;

		Cursor.SetCursor (null, hotSpot, cursorMode);
	}
}
