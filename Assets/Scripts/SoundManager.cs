using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public AudioSource sourcePtr;
	public static AudioSource source;
	
	void Awake()
	{
		SoundManager.source = sourcePtr;
	}

	// Use this for initialization
	public static void playEffect(AudioClip sound)
	{
		source.PlayOneShot(sound, 1f);
	}
}
