using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    [SerializeField] private GameObject restartSound;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "can_grapple" && col.gameObject.transform.position.y < transform.position.y)
        {
            spriteRenderer.sprite = sprites[0];
        }
    }

    private void Update()
    {
        if (transform.position.x < -10 || transform.position.x > 10)
        {
            Instantiate(restartSound, new Vector3(0, 0, 0), Quaternion.identity);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (transform.position.y < -5.5f || transform.position.y > 5.5f)
        {
            Instantiate(restartSound, new Vector3(0, 0, 0), Quaternion.identity);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
