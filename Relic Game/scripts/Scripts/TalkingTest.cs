using UnityEngine;
using System.Collections;

public class TalkingTest : MonoBehaviour {

	public TextAsset npcDialogue;
	string npcname;
	string[] dialogue;
	Rect dialogueRect = new Rect(Screen.width/2 -250, Screen.height -50, 500, 50);
	Rect npcnameRect = new Rect(Screen.width/2 -250, Screen.height -70, 100, 20);
	public static bool talking = false;
	
	int index = 0;
	
	
	// Use this for initialization
	void Start () {
		if (npcDialogue != null) {
			npcname = (npcDialogue.name);
			dialogue = (npcDialogue.text.Split( '\n' ));
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("return")) {
			index++;
		}
	}
	
	public void OnGUI(){
		if (talking) {
			if (index < dialogue.Length) {
				GUI.Box (npcnameRect, npcname);
				GUI.Box (dialogueRect, dialogue [index]);
			} else {
				TalkScript.inDialogue = false;
				talking = false;
				index = 0;
			}
		}
	}
}
