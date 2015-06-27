using UnityEngine;
using System.Collections;

public class DeathManager : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Trap") 
		{
			GameOverManager.GameOverScreen();
		}
	}

}
