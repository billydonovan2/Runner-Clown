using UnityEngine;
using System.Collections;

public class Shotgun : Weapon {
	protected override void Effect()
	{
		Vector3 rot = firePoint.rotation.eulerAngles;
		//Debug.Log ("Current is: " + rot);

		rot = new Vector3(rot.x, rot.y+40, rot.z);
		Quaternion rot1 = Quaternion.Euler(rot);

		rot = new Vector3(rot.x, rot.y+300, rot.z);
		Quaternion rot2 = Quaternion.Euler(rot);

		Vector3 pos1 = firePoint.position + new Vector3 (0f, 0.1f, 0f);
		Vector3 pos2 = firePoint.position + new Vector3 (0f, -0.1f, 0f);

		Instantiate (bulletTrailPrefab, firePoint.position, firePoint.rotation);
		Instantiate (bulletTrailPrefab, pos1, rot1);
		Instantiate (bulletTrailPrefab, pos2, rot2);
	}
}
