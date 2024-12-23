using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OzzyHealth : MonoBehaviour
{
    [Header("Characteristics")]
    private float health;
    public float[] phaseHealth;
    public int currentPhase = 0;
    public Image healthBar;

    [Header("Assignables")]
    public MeteorSpawn meteor;
    public SpawnerSauzzy sauz;
    
    public void Start()
    {
        health = phaseHealth[currentPhase];
    }

    public void TakeDamage(int damage)
    {

        health -= damage;
       
        healthBar.fillAmount = health / phaseHealth[currentPhase];

        
        die();
    }

    private void die()
    {
        if (health <= 0)
        {
            if (phaseHealth.Length - currentPhase != 1)
            {
                currentPhase++;
                health = phaseHealth[currentPhase];
                healthBar.fillAmount = health / phaseHealth[currentPhase];

                if (currentPhase == 1)
                {
                    meteor.enabled = false;
                    sauz.enabled = true;
                    sauz.cooldown = 6f;
                    sauz.Burst(3);
                }
                else if (currentPhase == 2)
                {
                    meteor.enabled = true;
                    sauz.cooldown = 10f;
                    

                }
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
    }
}
