using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject prefab;
	public float yPosition;
	public bool spawnAtExitTrigger = false;

	public bool randomSpawn = false;
	public int randomMin = 1;
	public int randomMax = 3;
	
	void Start()
	{
		if (randomSpawn)
		{
			Invoke("Spawn", Random.Range(randomMin, randomMax));
		}
	}

	void Spawn()
	{
		Vector3 pos = new Vector3 (transform.position.x - 1, yPosition, 0.0f);
		Instantiate (prefab, pos, Quaternion.identity);

		if (randomSpawn)
		{
			Invoke("Spawn", Random.Range(randomMin, randomMax));
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		//Debug.Log ("Create new platform" + other.gameObject.name.ToString());

		if (spawnAtExitTrigger)
			Spawn ();
	}
}
