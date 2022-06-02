using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum Front
    {
        Magma,
        Drill,
        Mole
    }
    public Front frontState;
    private ScoreManager scoreManager;

    [SerializeField]
    private float points = 1;

    [SerializeField]
    public float health = 1;

    [SerializeField]
    private GameObject background;

    [SerializeField, Tooltip("An array containing enemy sprites")] private Sprite[] fronts;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        scoreManager = FindObjectOfType<ScoreManager>();
        switch (frontState)
        {
            case (Front.Magma):
                spriteRenderer.sprite = fronts[0];
                break;
                
            case (Front.Drill):
                spriteRenderer.sprite = fronts[1];
                break;

            case (Front.Mole):
                spriteRenderer.sprite = fronts[2];
                break;
        }
        StartCoroutine(Flip());
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

    IEnumerator Flip()
    {
        while (true)
        {
            spriteRenderer.flipX = true;
            yield return new WaitForSecondsRealtime(0.5f);
            spriteRenderer.flipX = false;
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
