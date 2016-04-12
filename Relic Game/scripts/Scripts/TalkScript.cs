using UnityEngine;
using System.Collections;

public class TalkScript : MonoBehaviour {
	bool canTalk;
	public static bool inDialogue;


	void Update(){
		if (!inDialogue) {
			if (Input.GetKeyDown (KeyCode.E) & canTalk == true) {
				inDialogue = true;
				Debug.Log ("I am talking");
				TalkingTest.talking = true;

			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log (other);
		canTalk = true;
	}

	void OnTriggerExit2D(){
		canTalk = false;
		inDialogue = false;
	}
}
