using UnityEngine;
using System.Collections;

using UnityStandardAssets._2D;

public class GameSpeedManager : MonoBehaviour {
	public GameObject player;
	
	private float m_TimeSinceStart;
	private PlatformerCharacter2D m_PlayerScript;

	// Use this for initialization
	void Start () {
		m_PlayerScript = player.GetComponent<PlatformerCharacter2D>();
		m_TimeSinceStart = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
