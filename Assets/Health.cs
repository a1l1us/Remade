using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{

    public TextMeshProUGUI healthText;

    private float maxHealth;
    private float currentHealth;

    public void SetMaxHealth(int health)
    {
        maxHealth = health;
        currentHealth = health;
        healthText.text = currentHealth.ToString();
    }

    public void SetHealth(int health)
    {
        currentHealth = health;
        healthText.text = currentHealth.ToString();
    }
}
