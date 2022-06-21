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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {        
        if (col.gameObject.tag == "Player")
        {
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

    /*private void OnCollisionExit2D(Collision2D col)
    {
        canTug = false;
    }*/

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && canTug)
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
