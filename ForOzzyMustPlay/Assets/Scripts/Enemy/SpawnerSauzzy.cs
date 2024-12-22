using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSauzzy : MonoBehaviour
{
    public float cooldown = 7f;
    private bool CD;
    public GameObject[] sauzz;
    void Start()
    {
        
    }

    void Update()
    {
        if (!CD)
        {
            CD = true;
            Invoke(nameof(endCD), cooldown);
            for (int i = 0; i < Random.Range(2,4); i++)
            {
                if (Random.Range(0, 2) == 1)
                {
                    Instantiate(sauzz[0], new(-10, i * 4 + 7, 0), transform.rotation);
                }
                else
                {
                    Instantiate(sauzz[1], new(4, i * 4 + 7, 0), transform.rotation);

                }
            }
            
        }
    }

    void endCD()
    {
        CD = false;
    }
}
