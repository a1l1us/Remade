using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour

{ 
    public int maxHealth = 50;
    public int health;

    public HealthBar healthBar;
    public Health playerHealth;

    public void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerHealth.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        
        healthBar.SetHealth(health);
        playerHealth.SetHealth(health);
        
        if(health <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
