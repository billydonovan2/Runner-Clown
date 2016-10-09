using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour {
	public GameObject NoyEnoughMoneyWarning;
	
	[Header("Health")]
	public string healthButton1 = "Health_1";
	public string healthButton2 = "Health_2";
	public string healthButton3 = "Health_3";
	public int healthPrice1 = 20;
	public int healthPrice2 = 60;
	public int healthPrice3 = 200;
	
	[Header("HealthRegen")]
	public string healthRegenButton1 = "HealthRegen_1";
	public string healthRegenButton2 = "HealthRegen_2";
	public string healthRegenButton3 = "HealthRegen_3";
	public int healthRegenPrice1 = 20;
	public int healthRegenPrice2 = 60;
	public int healthRegenPrice3 = 200;
	
	[Header("Jump")]
	public string jumpButton1 = "Jump_1";
	public string jumpButton2 = "Jump_2";
	public string jumpButton3 = "Jump_3";
	public int jumpPrice1 = 20;
	public int jumpPrice2 = 60;
	public int jumpPrice3 = 200;
	
	private PlayerInfo playerInfo;
	private GameObject button;
	
	private Dictionary<int, int> healthDict;
	private Dictionary<int, int> healthRegenDict;
	private Dictionary<int, int> jumpDict;
	
	void Awake()
	{
		this.playerInfo = PlayerInfo.Instance;
		playerInfo.LoadPlayerInfo();
		
		healthDict = new Dictionary<int, int>(){
			{1, healthPrice1},
			{2, healthPrice2},
			{3, healthPrice3}};
			
		healthRegenDict = new Dictionary<int, int>(){
			{1, healthRegenPrice1},
			{2, healthRegenPrice2},
			{3, healthRegenPrice3}};
			
		jumpDict = new Dictionary<int, int>(){
			{1, jumpPrice1},
			{2, jumpPrice2},
			{3, jumpPrice3}};
			
			this.CheckBouthItems();
	}
	
	void CheckBouthItems()
	{
		for (int i = 0; i < 3; i++)
		{
			//Debug.Log("Bought Health_"+i+" "+this.playerInfo.storeHealth[i]);
			//Debug.Log("Bought Health_"+i+" "+this.playerInfo.storeHealthRegen[i]);
			//Debug.Log("Bought Health_"+i+" "+this.playerInfo.storeJump[i]);
			
			if (this.playerInfo.storeHealth[i]) {				
				button = GameObject.Find("Health_"+(i+1));
				Buy(button);
			}
			
			if (this.playerInfo.storeHealthRegen[i]) {
				button = GameObject.Find("HealthRegen_"+(i+1));
				Buy(button);
			}
			
			if (this.playerInfo.storeJump[i]) {
				button = GameObject.Find("Jump_"+(i+1));
				Buy(button);
			}
		}
		
	}
	
	bool CanBuy(Dictionary<int, int> d, int idx)
	{
		NoyEnoughMoneyWarning.SetActive(false);
		
		if (d[idx] > ScoreManager.GetCurrentCoins()) {
			Debug.Log("Cannot buy. Coins: " + ScoreManager.GetCurrentCoins());
			
			NoyEnoughMoneyWarning.SetActive(true);
			
			return false;
		}
		return true;
	}
	
	void Buy(GameObject btnObj)
	{
		Button btn = btnObj.GetComponent<Button>();
		btn.interactable = false;
		
		Component[] imgs = btnObj.GetComponentsInChildren<Image>();
		foreach (Image image in imgs) {
            image.color = Color.red;
        }
	}
	
	void ConfimPurchase(int amount)
	{
		ScoreManager.DecreaseScore(amount);
	}
	
	public void BuyHealth(int index)
	{
		button = GameObject.Find("Health_"+index);
		Debug.Log("Health_"+index);
		
		if(CanBuy(healthDict, index))
		{
			Buy(button);
			this.playerInfo.storeHealth[index-1] = true;
			this.playerInfo.SavePlayerInfo();
			
			ConfimPurchase(healthDict[index]);
		}		
	}
	
	public void BuyHealthRegen(int index)
	{
		button = GameObject.Find("HealthRegen_"+index);
		Debug.Log("HealthRegen_"+index);
		
		if(CanBuy(healthRegenDict, index))
		{
			Buy(button);
			this.playerInfo.storeHealthRegen[index-1] = true;
			this.playerInfo.SavePlayerInfo();
			
			ConfimPurchase(healthRegenDict[index]);
		}	
	}
	
	public void BuyJump(int index)
	{
		button = GameObject.Find("Jump_"+index);
		Debug.Log("Jump_"+index);
		
		if(CanBuy(jumpDict, index))
		{
			Buy(button);
			this.playerInfo.storeJump[index-1] = true;
			this.playerInfo.SavePlayerInfo();
			
			ConfimPurchase(jumpDict[index]);	
		}	
	}
	
	public void EraseAllPurchases()
	{
		for (int i = 0; i < 3; i++)
		{
			this.playerInfo.storeHealth[i] = false;
			this.playerInfo.storeHealthRegen[i] = false;
			this.playerInfo.storeJump[i] = false;
		}
		
		ScoreManager sm = ScoreManager.Instance;
		sm.score = 0;		
		
		ScoreManager.IncreaseScore(0);
		
		this.playerInfo.SavePlayerInfo();
	}
}
