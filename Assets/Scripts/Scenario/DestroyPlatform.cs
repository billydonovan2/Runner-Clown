using UnityEngine;
using System.Collections;

public class DestroyPlatform : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D other)
	{
		// Debug.Log ("Destroy platform");

		if (other.gameObject.transform.parent) {
			Destroy (other.gameObject.transform.parent.gameObject);
		} else {
			Destroy (other.gameObject);
		}
	}
}
