using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int deathScore = 40;
	public int life = 20;

	public void doDamage(int damage)
	{
		Debug.Log ("Damage taken. Still have " + life);
		this.life -= damage;

		if (this.life <= 0)
		{
			IamDead ();
		}
	}

	void IamDead()
	{
		ScoreManager.IncreaseScore(deathScore);
		Destroy (gameObject);
	}
}
