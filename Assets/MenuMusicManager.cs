using UnityEngine;
using System.Collections;

public class MenuMusicManager : Singleton<MenuMusicManager> {
	public AudioClip ambientSound;
	public AudioSource source;
	public bool killMusicOnStart;

	// Use this for initialization
	void Awake () {
		if (this != MenuMusicManager.Instance)
		{
			Debug.Log("should die");
			Destroy(gameObject);
		}
		DontDestroyOnLoad(transform.gameObject);
	}
	
	void Start()
	{
		source.clip = ambientSound;
		source.Play();
	}
	
	public void StopMusic () {
		source.Stop();
	}
}
