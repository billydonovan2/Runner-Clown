using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour {
	public int damage;
	private bool colliderEnable = true;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (!this.colliderEnable) return;
			this.colliderEnable = false;
			
			Debug.Log("Rock died!");
			Rigidbody2D rb = GetComponent<Rigidbody2D>();
			rb.constraints = RigidbodyConstraints2D.FreezePositionY;
			GetComponent<Collider2D>().isTrigger = true;
			
			GameObject.Find("Player").GetComponent<HealthManager>().decreaseHealth(damage);
		}
	}
}
