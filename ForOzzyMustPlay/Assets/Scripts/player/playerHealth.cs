using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float maxHealth;
    private float health;
    public Image healthBar;

    void Start()
    {
        health = maxHealth;
    }

    public void takeDamage(int damage)
    {
        
        health -= damage;
        healthBar.fillAmount = health / maxHealth;
        die();
    }

    void die()
    {
        if (health <= 0)
        {
            Debug.Log("Game over!!");
        }
    }
}
