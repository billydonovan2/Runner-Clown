using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
    public float velocity = 1;
	// Update is called once per frame
	void Update () {
	    // give it 
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.velocity, GetComponent<Rigidbody2D>().velocity.y);
	}
}
