using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {
	public static int score;
	public GameObject textUI;
	public AudioClip coinSound;
	public AudioSource source;
	
	private static Text text;
	

	void Awake()
	{
		text = textUI.GetComponent<Text> ();
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score: " + score;
	}

	public static void IncreaseScore(int amount)
	{
		ScoreManager.score += amount;
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag == "Coin25")
		{
			source.PlayOneShot(coinSound, 1f);
			ScoreManager.IncreaseScore(25);
			Destroy(other.gameObject);
		}
    }
}
