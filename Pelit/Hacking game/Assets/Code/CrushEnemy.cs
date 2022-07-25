using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject deathParticle;

    [SerializeField] private GameObject enemyDeathSound;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Instantiate(deathParticle, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Instantiate(enemyDeathSound, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Destroy(col.gameObject);
        }
    }
}
