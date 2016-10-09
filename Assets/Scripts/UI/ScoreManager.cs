using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : Singleton<ScoreManager> {
	public int score;
	public GameObject textUI;
	public AudioClip coinSound;
	public AudioSource source;
	
	private PlayerInfo playerInfo;
	private static Text text;

	void Awake()
	{
		Debug.Log("Loading ScoreManager");
		
		playerInfo = PlayerInfo.Instance;
		playerInfo.LoadPlayerInfo();
		
		text = textUI.GetComponent<Text> ();
		score = playerInfo.coins;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "" + score;
	}

	public static void IncreaseScore(int amount)
	{
		ScoreManager sm = ScoreManager.Instance;
		
		sm.source.PlayOneShot(sm.coinSound, 1f);
		sm.score += amount;
		
		sm.playerInfo.coins = sm.score;
		sm.playerInfo.SavePlayerInfo();
	}
	
	public static void DecreaseScore(int amount)
	{
		ScoreManager sm = ScoreManager.Instance;
		
		sm.source.PlayOneShot(sm.coinSound, 1f);
		sm.score -= amount;
		
		sm.playerInfo.coins = sm.score;
		sm.playerInfo.SavePlayerInfo();
	}
	
	public static int GetCurrentCoins()
	{
		ScoreManager sm = ScoreManager.Instance;
		return sm.score;
	}
}
