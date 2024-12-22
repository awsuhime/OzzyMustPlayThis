using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public bool saver = false;
    public bool destroy = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHealth health = collision.gameObject.GetComponent<playerHealth>();
            health.takeDamage(damage);
            if (saver)
            {
                gameObject.SetActive(false);


            }
            else if (destroy)
            {
                Destroy(gameObject);

            }
        }
    }
}
