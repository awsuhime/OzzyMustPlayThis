using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilePlayer : MonoBehaviour
{
    public float speed;
    public int damage = 1;
    public int pierce = 1;
    private EnemyHealth enemyHealth;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(damage);
            pierce--;
            if (pierce == 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
