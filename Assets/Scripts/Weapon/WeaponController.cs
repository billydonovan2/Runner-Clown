﻿using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {
    private Animator m_Anim;            // Reference to the player's animator component.


    // Use this for initialization
    void Start () {
        m_Anim = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update () {
    }

    // Use this method to attack with the weapon
    public void Attack ()
    {
        Debug.Log("I need to shoot!");
        m_Anim.SetTrigger("Attack");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Weapon trigger BEGIN");
        
        if (other.gameObject.tag == "zombie")
        {
            ZombieController zc = (ZombieController) other.GetComponent<ZombieController>();
            if (zc) zc.zombieDeath();
        }
     }
     
     
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Weapon trigger EXIT");
     }
}
