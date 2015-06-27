using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {
	public float fireRate = 0.0f;
	public int damage = 10;
	public Vector2 bulletForce = new Vector2(0f, 0f);
	public LayerMask hitLayers;
	public int ammunition = 10;

	public Transform bulletTrailPrefab;

	float timeToFire = 0f;
	protected Transform firePoint;

	void Awake()
	{
		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null)
		{
			Debug.LogError ("ERROR: No FirePoint");
		}
	}

	void Update()
	{
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1"))
			{
				Shoot();
			}
		}
		else if (Input.GetButton("Fire1") && Time.time > timeToFire)
		{
			timeToFire = Time.time + 1/fireRate;
			Debug.Log("multiple burst");
		}
	}

	void Shoot()
	{
		//Debug.Log ("shooting");

		if (AmmunitionManager.getAmmoQuantity() < 1)
		{
			return;
		}


		Vector2 mousePos = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x,
		                                Camera.main.ScreenToWorldPoint (Input.mousePosition).y);
		Vector2 firePointPos = new Vector2 (firePoint.position.x,
		                                    firePoint.position.y);

		Vector2 direction = mousePos - firePointPos;
		Debug.DrawLine (firePointPos, mousePos);
		
		RaycastHit2D hit = Physics2D.Raycast (firePointPos,
		                                      direction,
		                                      100,
		                                      this.hitLayers);

		// Do the bullet stuff
		AmmunitionManager.spendAmmo (1);
		Effect ();

		/*if (hit.collider != null)
		{
			Debug.DrawLine (firePointPos, hit.point);
			Debug.Log ("Hit something! " + hit.transform.tag);

			//hit.transform.GetComponent<Rigidbody2D>().velocity = new Vector2(4f, 2f);
			Rigidbody2D otherRigidBody = hit.transform.GetComponent<Rigidbody2D>();

			otherRigidBody.velocity = new Vector2(2f, 0f);
			otherRigidBody.AddForceAtPosition(bulletForce, hit.point);
		}*/
	}

	protected virtual void Effect()
	{
		Debug.Log ("Weapon.effect");
		Instantiate (bulletTrailPrefab, firePoint.position, firePoint.rotation);
	}
}
