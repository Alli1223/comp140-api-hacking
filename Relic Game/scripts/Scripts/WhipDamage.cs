using UnityEngine;
using System.Collections;

public class WhipDamage : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other) {
		Debug.Log(gameObject.tag + " entered Collision tagged " + other.gameObject.tag);
		if (other.gameObject.tag == "Enemy") {
			Destroy (other.gameObject);
		}
		}
}

