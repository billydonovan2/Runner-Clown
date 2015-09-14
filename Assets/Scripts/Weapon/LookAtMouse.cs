using UnityEngine;
using System.Collections;

public class LookAtMouse : MonoBehaviour
{
	
	// speed is the rate at which the object will rotate
	public int offset = 0;
	
	void FixedUpdate () 
	{
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Vector3 thisPosition = transform.position;

		Vector3 difference = (mousePos - thisPosition);
		difference.Normalize ();

		//Debug.DrawRay (thisPosition, mousePos - thisPosition, Color.white);

		float zRot = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler (0f, 0f, zRot + offset);
	}
}