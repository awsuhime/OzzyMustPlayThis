using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Resolvers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("Characteristics")]
    public float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundMask;

    [Header("Status")]

    public static bool movable = true;
    public static bool jumpable = true;
    
    private bool firstJump = true;
    private bool doubleJump = true;
    private bool grounded;

    


    void Start()
    {
        
    }
    private void Update()
    {
        //Jumping
        
        grounded = Physics2D.Raycast(transform.position, Vector2.down, 1f, groundMask);
        if (rb.velocity.y > 0)
        {
            grounded = false;
        }
            if (grounded)
        {
            firstJump = true;
        }
        if (jumpable && Input.GetKeyDown(KeyCode.Space))
        {
            if (firstJump)
            {
                rb.velocity = new Vector2(rb.velocity.y, jumpHeight);
                firstJump = false;
                doubleJump = true;
            }
            else if (doubleJump)
            {
                doubleJump = false;
                rb.velocity = new Vector2(rb.velocity.y, jumpHeight);
            }
            
            
        }

        
    }
    void FixedUpdate()
    {
        float hori = Input.GetAxisRaw("Horizontal");
        if (movable)
        {
           
            
            rb.velocity = new Vector2(hori * speed, rb.velocity.y);
            
        }
       

    }

    
}
