using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NormalEnemyHitDetection : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canTug;
    [SerializeField] private GameObject player;
    private bool safeGuard = true;
    [SerializeField] private float forceAmount;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "hook")
        {
            GetComponent<NormalEnemy>().enabled = false;
            canTug = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (safeGuard)
        {
            GetComponent<NormalEnemy>().enabled = true;
            canTug = false;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && canTug)
        {
            safeGuard = false;
            rb.AddForce((player.transform.position - transform.position) * forceAmount);
        }
    }
}
