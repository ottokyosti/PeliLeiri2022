using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    private Vector2 direction;
    public Vector2 _direction
    {
        get { return direction; }
        set { direction = value; }
    }

    [SerializeField] private float speed;

    private float destroyTimer = 10f;

    private void Update()
    {
        if (destroyTimer <= 0f)
        {
            Destroy(this.gameObject);
        }
        else 
        {
            destroyTimer -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            SceneManager.LoadScene(0);
        }
        else if (col.gameObject.layer == 7)
        {
            Destroy(this.gameObject);
        }
    }
}
