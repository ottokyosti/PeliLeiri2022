using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private ScoreManager scoreManager;

    [SerializeField]
    private float points = 1;

    [SerializeField]
    public float health = 1;

    [SerializeField]
    private GameObject background;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            scoreManager.AddScore(points);
            Instantiate(background, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
