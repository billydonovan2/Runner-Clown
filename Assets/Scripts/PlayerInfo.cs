using UnityEngine;
using System.Collections;

public class PlayerInfo : Singleton<PlayerInfo> {
	public int coins;
	
	public bool[] storeHealth = new bool[3];
	public bool[] storeHealthRegen = new bool[3];
	public bool[] storeJump = new bool[3];
	
	private void SetBool(string name, bool booleanValue) { PlayerPrefs.SetInt(name, booleanValue ? 1 : 0); }
	private bool GetBool(string name)  { return PlayerPrefs.GetInt(name) == 1 ? true : false; }
	
	void Awake()
	{
		Debug.Log("Loaded PlayerInfo");
	}
	
	public void LoadPlayerInfo()
	{
		this.coins = PlayerPrefs.GetInt("coins");
		
		this.storeHealth[0] = this.GetBool("storeHealth1");
		this.storeHealth[1] = this.GetBool("storeHealth2");
		this.storeHealth[2] = this.GetBool("storeHealth3");
		
		this.storeHealthRegen[0] = this.GetBool("storeHealthRegen1");
		this.storeHealthRegen[1] = this.GetBool("storeHealthRegen2");
		this.storeHealthRegen[2] = this.GetBool("storeHealthRegen3");
		
		this.storeJump[0] = this.GetBool("storeJump1");
		this.storeJump[1] = this.GetBool("storeJump2");
		this.storeJump[2] = this.GetBool("storeJump3");
	}
	
	public void SavePlayerInfo()
	{
		PlayerPrefs.SetInt("coins", this.coins);
		
		this.SetBool("storeHealth1", this.storeHealth[0]);
		this.SetBool("storeHealth2", this.storeHealth[1]);
		this.SetBool("storeHealth3", this.storeHealth[2]);
		
		this.SetBool("storeHealthRegen1", this.storeHealthRegen[0]);
		this.SetBool("storeHealthRegen2", this.storeHealthRegen[1]);
		this.SetBool("storeHealthRegen3", this.storeHealthRegen[2]);
		
		this.SetBool("storeJump1", this.storeJump[0]);
		this.SetBool("storeJump2", this.storeJump[1]);
		this.SetBool("storeJump3", this.storeJump[2]);
		
		
		PlayerPrefs.Save();
	}
}
