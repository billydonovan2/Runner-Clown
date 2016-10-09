using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManager : MonoBehaviour {
    public float maxHealth = 100;
    
    public Slider healthSlider;
    public float healthIncreaseTimeInterval;
    public float healthIncreaseOverTime;
    
    private Image fillColor;   
    private float timeBeforeIncreaseSpeed;
    private float health;

    // Use this for initialization
    void Awake () {
        PlayerInfo pi = PlayerInfo.Instance;
        pi.LoadPlayerInfo();
        
        this.maxHealth = this.maxHealth + (25 * Convert.ToInt32(pi.storeHealth[0]))
                                        + (25 * Convert.ToInt32(pi.storeHealth[1]))
                                        + (25 * Convert.ToInt32(pi.storeHealth[2]));
        
        this.healthIncreaseTimeInterval = this.healthIncreaseTimeInterval - (.25f * Convert.ToInt32(pi.storeHealthRegen[0]))
                                                                          - (.25f * Convert.ToInt32(pi.storeHealthRegen[1]))
                                                                          - (.50f * Convert.ToInt32(pi.storeHealthRegen[2]));
        
        
        this.fillColor = healthSlider.GetComponentInChildren<UnityEngine.UI.Image>();
        this.fillColor.color = Color.green;
        this.health = maxHealth;
        
        this.timeBeforeIncreaseSpeed = this.healthIncreaseTimeInterval;
        
        Debug.Log("Mex Health is: " + this.health);
    }
    
    void Update()
    {
        if (health < maxHealth)
        {
            timeBeforeIncreaseSpeed -= Time.deltaTime;
            
            if (timeBeforeIncreaseSpeed <= 0)
            {
                timeBeforeIncreaseSpeed = healthIncreaseTimeInterval;
                this.health += healthIncreaseOverTime;
                
                if (this.health > this.maxHealth) this.health = this.maxHealth;
            }
        }
        
        this.updateHealthBar(this.calculateHealthPercentage());
    }
    
    void updateHealthBar(float healthPercentage)
    {
        this.healthSlider.value = healthPercentage;
        Color c = new Color(2 * (1-healthPercentage), 2 * healthPercentage, 0F, 1F);
        this.fillColor.color = c;
    }
    
    float calculateHealthPercentage()
    {
        float healthPercentage = this.health / this.maxHealth;        
        return healthPercentage;
    }

    public void decreaseHealth(int amount)
    {
        this.health -= amount;
    }

    bool isDead()
    {
        bool ret = false;

        if (this.health <= 0)
            ret = true;

        return ret;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Untagged") return;
        if (other.gameObject.tag == "trap") 
        {
            this.decreaseHealth(25);
        }

        if (other.gameObject.tag == "zombie")
        {
            this.decreaseHealth(40);
        }

        if (this.isDead())
            GameOverManager.GameOverScreen();
    }

}
