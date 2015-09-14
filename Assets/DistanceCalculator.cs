using UnityEngine;
using System.Collections;

public class DistanceCalculator : MonoBehaviour {
	public GameObject obj;

	private Vector3 lastPosition;
	private float   traveledDistance;

	private float   totalTime;
	private float   nextInterval;

	// Use this for initialization
	void Start () {
		this.lastPosition = obj.transform.position;
		this.traveledDistance = 0;

		this.totalTime = Time.time;
		this.nextInterval = 1;
	}
	
	// Update is called once per frame
	void Update () {
		this.traveledDistance += Vector3.Distance(this.lastPosition, obj.transform.position);
		this.lastPosition = obj.transform.position;

		// Uncomment this to know how many meters is running pr second
		this.totalTime += Time.deltaTime;
		if (this.totalTime > this.nextInterval) {
			this.nextInterval += 1;
			Debug.Log (this.traveledDistance + " " + this.totalTime);
		}
	}
}
