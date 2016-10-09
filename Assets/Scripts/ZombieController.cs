using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
    public float velocity = 1;
	public AudioClip deathSound;
	public bool PlaySound;
	
	private bool colliderEnable = true;
	private Animator m_Anim;
	
	private void Awake()
	{
		m_Anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.velocity, 
														GetComponent<Rigidbody2D>().velocity.y);
	}
	
	public void zombieDeath()
	{
		if (!this.colliderEnable) return;
		this.colliderEnable = false;
		
		Debug.Log("Zombie died!");
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		rb.constraints = RigidbodyConstraints2D.FreezePositionY;
		GetComponent<Collider2D>().isTrigger = true;
		
		if (PlaySound) SoundManager.playEffect(deathSound);
		m_Anim.SetBool("isDead", true);
		
		Invoke("DestroyThisObject", 1.0f);
		
	}
	
	void DestroyThisObject()
	{
		Destroy(this.gameObject);
	}
}
