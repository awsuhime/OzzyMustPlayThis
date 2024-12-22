using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSplit : MonoBehaviour
{
    public GameObject splitProj;
    public bool big = false;
    private Rigidbody2D rb;
    public float vertPower = 3;
    public float horiPower = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!big)
            {
                Instantiate(splitProj, transform.position, Quaternion.Euler(0f, 0f, 0f));
                Instantiate(splitProj, transform.position, Quaternion.Euler(0f, 0f, 180f));
            }
            else
            {
                GameObject split = Instantiate(splitProj, transform.position, Quaternion.Euler(0f, 0f, 0f));
                rb = split.GetComponent<Rigidbody2D>();
                rb.AddForce(new (horiPower, vertPower), ForceMode2D.Impulse);
                split = Instantiate(splitProj, transform.position, Quaternion.Euler(0f, 0f, 0f));
                rb = split.GetComponent<Rigidbody2D>();
                rb.AddForce(new(-horiPower, vertPower), ForceMode2D.Impulse);
            }
            gameObject.SetActive(false);
        }
    }

}
