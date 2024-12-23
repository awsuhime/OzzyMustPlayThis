using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSauzzy : MonoBehaviour
{
    public float cooldown = 7f;
    private bool CD;
    public GameObject[] sauzz;
    private GameObject currentSauz;
    private SauzzySpawn spawn;
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
                    currentSauz = Instantiate(sauzz[0], new(-10, i * 4 + 7, 0), transform.rotation);
                }
                else
                {
                    currentSauz = Instantiate(sauzz[1], new(4, i * 4 + 7, 0), transform.rotation);

                }
                spawn = currentSauz.GetComponent<SauzzySpawn>();
                spawn.reloadTime = Random.Range(1.6f, 2.4f);
            }
            
        }
    }

    public void Burst(int burst)
    {
        for (int i = 0; i < burst; i++)
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

    void endCD()
    {
        CD = false;
    }
}
