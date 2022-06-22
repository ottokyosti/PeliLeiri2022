using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool canTug;
    [SerializeField] private float forceAmount;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject restartSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {        
        if (col.gameObject.tag == "Player")
        {
            Instantiate(restartSound, transform.position, transform.rotation);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "hook")
        {
            canTug = true;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && canTug)
        {
            if (player.transform.position.x > transform.position.x)
            {
                rb.AddForce(new Vector2(forceAmount, 0));
            }
            else if (player.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(-(forceAmount), 0));
            }
        }

        if (transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }
}
