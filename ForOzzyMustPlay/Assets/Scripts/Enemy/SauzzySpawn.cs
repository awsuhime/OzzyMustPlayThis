using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SauzzySpawn : MonoBehaviour
{
    public float reloadTime = 2f;
    private bool reloaded = false;
    public GameObject spawn;
    void Start()
    {
        Invoke(nameof(reload), reloadTime);
    }

    void Update()
    {
        if (reloaded)
        {
            reloaded = false;
            Invoke(nameof(reload), reloadTime);
            Instantiate(spawn, new (transform.position.x, transform.position.y + 0.2f, 0f), transform.rotation);

        }
    }

    private void reload()
    {
        reloaded = true;
    }
}
