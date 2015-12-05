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
    void Start () {
        this.fillColor = healthSlider.GetComponentInChildren<UnityEngine.UI.Image>();
        this.fillColor.color = Color.green;
        this.health = maxHealth;
        
        timeBeforeIncreaseSpeed = healthIncreaseTimeInterval;
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

    void decreaseHealth(int amount)
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
