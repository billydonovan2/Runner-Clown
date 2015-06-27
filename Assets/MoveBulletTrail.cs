using UnityEngine;
using System.Collections;

public class MoveBulletTrail : MonoBehaviour {
	public int speed = 230;
	public Vector2 bulletForce = new Vector2(0f, 0f);
	public int damage = 0;

	private int totalDamage;

	void Start()
	{
		Destroy (this.gameObject, 2f);
		this.totalDamage = this.damage + GameObject.Find("EquippedWeapon").GetComponentInChildren <Weapon>().damage;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		EffectOnOther(other.gameObject.GetComponent<Rigidbody2D>());
		Destroy (this.gameObject);

	}

	void EffectOnOther(Rigidbody2D other)
	{
		//other.velocity = new Vector2(2f, 0f);
		other.AddForceAtPosition(bulletForce, transform.position);

		Enemy e = other.gameObject.GetComponent<Enemy> ();
		if (e != null) 
		{
			e.doDamage(this.totalDamage);
		}
	}

}
