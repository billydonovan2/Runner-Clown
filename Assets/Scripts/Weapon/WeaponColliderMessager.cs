using UnityEngine;
using System.Collections;

public class WeaponColliderMessager : MonoBehaviour {
    public WeaponController wc;

    void OnDestroy() {
        print("Script was destroyed");
    }
    
    // Use this for initialization
    void Start () {
        wc = (WeaponController) this.GetComponentInParent<WeaponController>();
    }
    
    // Update is called once per frame
    void Update () {
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Weapon messager trigger - BEGIN");
        
        wc.SendMessage("OnTriggerEnter2D", other);
        wc.SendMessage("OnTriggerExit2D", other);
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Weapon messager trigger - EXIT");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Weapon messager collided");
    }
}