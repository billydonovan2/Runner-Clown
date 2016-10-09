﻿using UnityEngine;
using System.Collections;

public class CollectCoin : MonoBehaviour {
	public int coinValue = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.tag == "Player")
		{			
			ScoreManager.IncreaseScore(coinValue);
			Destroy(gameObject);
		}
    }
}
