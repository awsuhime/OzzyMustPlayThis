using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100;
    private float health;
    public Image healthBar;
    public bool bigBar = false;
    public bool saver = false;

    public void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        
        health -= damage;
        if (bigBar)
        {
            healthBar.fillAmount = health / maxHealth;

        }
        die();
    }

    private void die()
    {
        if (health <= 0)
        {
            if (!saver)
            {
                Destroy(gameObject);

            }
            else
            {
                gameObject.SetActive(false);
            }

        }
    }
}
