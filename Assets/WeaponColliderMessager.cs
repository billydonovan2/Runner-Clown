using UnityEngine;
using System.Collections;

public class WeaponColliderMessager : MonoBehaviour {

    // Use this for initialization
    void Start () {
    
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        this.transform.parent.SendMessage("OnTriggerEnter2D", other);
    }
}
