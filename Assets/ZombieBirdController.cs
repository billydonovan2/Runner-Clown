using UnityEngine;
using System.Collections;

public class ZombieBirdController : MonoBehaviour {
	public int damage;
	
	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag == "Player")
		{			
			//Debug.Log("bateu no passaro");
			GameObject.Find("Player").GetComponent<HealthManager>().decreaseHealth(damage);
		}
    }
}
