using UnityEngine;
using System.Collections;

public class ScoreRegister : MonoBehaviour {
	public int scoreAmount = 0;
	private bool scoreGiven = false;
	
	void OnTriggerExit2D(Collider2D other)
	{
		//Debug.Log (this.tag);

		if (other.tag == "Player" && this.gameObject.layer == LayerMask.NameToLayer("Points") && !scoreGiven) 
		{
			ScoreManager.IncreaseScore(this.scoreAmount);
			scoreGiven = true;
		}
	}
}
