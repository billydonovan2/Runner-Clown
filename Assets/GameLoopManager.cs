﻿using UnityEngine;
using System.Collections;

public class GameLoopManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void restartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
