using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dashProjectile : MonoBehaviour
{
    [Header("Characteristics")]
    public float range = 5;
    public float speed = 5;
    public bool collided;

    [Header("Status")]
    public Vector3 startPos;
    public Vector3 mousePos;
    public bool ready = false;
    public Vector3 givenPos;
    public GameObject particle;

    

    private void Update()
    {
        if (Mathf.Abs((transform.position - startPos).magnitude) >= range)
        {
            if (ready)
            {
                //Debug.Log("Ready, other");
                //Instantiate(particle, transform.position, transform.rotation);
                ready = false;
                givenPos = transform.position;
            }
           
        }
    }
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed);

    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.isTrigger)
        {
            
            if (ready)
            {
                collided = true;

                Debug.Log("Ready, collision touched");
                ready = false;
                givenPos = transform.position;
            }
           
        }
    }
    */
}
