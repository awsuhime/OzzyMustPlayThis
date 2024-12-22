using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{

    //Status
    private bool shootable = true;
    private bool reloaded = true;
    private bool dashable = true;
    private bool dashCD = false;
    private int charges;
    private bool recharging;

    [Header("Characteristics")]
    public float reloadTime;
    public int maxCharges = 3;
    public float chargeTime = 1;

    [Header("Assignables")]
    public Rigidbody2D rb;
    public BoxCollider2D boxCollider;
    public Camera cam;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject radius;
    private dashProjectile DashProjectile;
    public GameObject chargeParticle;

    [Header("Projectiles")]
    public GameObject projectile;
    public GameObject superProjectile;
    public GameObject dash;

    //Mouse vars
    private Vector3 rotation;
    private Vector3 mousePos;
    private float rotz;

    
    void Start()
    {
        DashProjectile = dash.GetComponent<dashProjectile>();
        charges = maxCharges;
    }

    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rotation = mousePos - transform.position;
        rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        //Shooting
        if (shootable && Input.GetMouseButton(0) && reloaded)
        {

            reloaded = false;
            Invoke(nameof(Reload), reloadTime);

            
            Instantiate(projectile, transform.position, Quaternion.Euler(0f, 0f, rotz));
        }
        if (dashable && !dashCD && Input.GetKeyDown(KeyCode.LeftShift) && charges > 0)
        {
            charges--;
            
            if (!recharging)
            {
                recharging = true;
                Invoke(nameof(recharge), chargeTime);

            }

            boxCollider.enabled = false;
            dashCD = true;
            playerMovement.jumpable = false;
            playerMovement.movable = false;
            shootable = false;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            radius.SetActive(true);
            Invoke(nameof(dashStart), 0.2f);


        }
        if (shootable && Input.GetKeyDown(KeyCode.E) && charges>0)
        {
            Instantiate(superProjectile, transform.position, Quaternion.Euler(0f, 0f, rotz));
            charges--;
            if (!recharging)
            {
                recharging = true;

                Invoke(nameof(recharge), chargeTime);

            }
        }
    }

    void Reload()
    {
        reloaded = true;
    }
    void dashStart()
    {
        radius.SetActive(false);

        dash.transform.position = transform.position;
        DashProjectile.startPos = transform.position;
        dash.transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        dash.SetActive(true);
        DashProjectile.mousePos = mousePos;
        DashProjectile.collided = false;
        DashProjectile.ready = true;
        spriteRenderer.enabled = false;
        Invoke(nameof(dashEnd), 0.2f);


    }
    void dashEnd()
    {
        spriteRenderer.enabled = true;

        if ((DashProjectile.mousePos - transform.position).magnitude < DashProjectile.range)
        {
            Debug.Log("Overrided dash");
            transform.position = new Vector3 (DashProjectile.mousePos.x, DashProjectile.mousePos.y, 0);
        }
        else
        {
            transform.position = DashProjectile.givenPos;

        }
        boxCollider.enabled = true;
        dash.SetActive(false);
        rb.velocity = new Vector2(0, 0.5f);
        playerMovement.jumpable = true;
        playerMovement.movable = true;
        shootable = true;
        rb.gravityScale = 2.5f;

        Invoke(nameof(dashCDEnd), 0.5f);

    }
    void dashCDEnd()
    {
        dashCD = false;
    }

    void recharge()
    {
        charges++;
        Instantiate(chargeParticle, transform.position, transform.rotation);
        if (charges < maxCharges)
        {
            Invoke(nameof(recharge), chargeTime);
        }
        else
        {
            recharging = false;
        }
    }
}
