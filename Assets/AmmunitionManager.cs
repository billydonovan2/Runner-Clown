using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmunitionManager : MonoBehaviour {
	public int startWith = 10;
	public static int ammo;

	Text text; 

	// Use this for initialization
	void Awake()
	{
		text = GetComponent<Text> ();
		ammo = startWith;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "" + ammo;
	}

	public static void spendAmmo(int amount)
	{
		AmmunitionManager.ammo -= amount;
	}

	public static void addAmmo(int amout)
	{
		AmmunitionManager.ammo += amout;
	}

	public static int getAmmoQuantity()
	{
		return AmmunitionManager.ammo;
	}
}
