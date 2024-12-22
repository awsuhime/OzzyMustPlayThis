using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawn : MonoBehaviour
{
    public GameObject[] meteor;
    public GameObject[] bigMeteor;
    public float cooldown = 7f;
    private bool CD;
    void Start()
    {
        
    }

    void Update()
    {
        if (!CD)
        {
            CD = true;
            Invoke(nameof(endCD), cooldown);
            for(int i = 0; i < meteor.Length; i++)
            {
                meteor[i].SetActive(true);
                meteor[i].transform.position = new Vector3(Random.Range(-8f, 8f), i * 7 + 9f * Random.Range(0.8f, 1.2f), 0f);
                meteor[i].transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(260f, 280f));
            }
            for (int i = 0; i < bigMeteor.Length; i++)
            {
                bigMeteor[i].SetActive(true);
                bigMeteor[i].transform.position = new Vector3(Random.Range(-8f, 8f), i * 19 + 18f * Random.Range(0.8f, 1.2f), 0f);
                bigMeteor[i].transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(260f, 280f));
            }
        }
    }

    private void endCD()
    {
        CD = false;
    }
}
