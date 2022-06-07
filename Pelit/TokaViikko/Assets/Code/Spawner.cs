using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private bool vertical;

    [SerializeField]
    private GameObject spawnObject;

    [SerializeField]
    private float limNegative;

    [SerializeField]
    private float limPositive;

    [SerializeField]
    private float spawnTimer;

    [SerializeField]
    private float spawnOffset = 0;

    private float origSpawnTimer;

    private float spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        origSpawnTimer = spawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if(spawnTimer <= 0)
        {
            Spawn();
            spawnTimer = origSpawnTimer + Random.Range(-spawnOffset, spawnOffset);
        }
    }

    private void Spawn()
    {
        spawnPoint = Random.Range(limNegative, limPositive);
        if(vertical)
        {
            Instantiate(spawnObject, new Vector3(transform.position.x, transform.position.y + spawnPoint, transform.position.z), transform.rotation);
        }
        else
        {
            Instantiate(spawnObject, new Vector3(transform.position.x + spawnPoint, transform.position.y, transform.position.z), transform.rotation);
        }
    }
}
