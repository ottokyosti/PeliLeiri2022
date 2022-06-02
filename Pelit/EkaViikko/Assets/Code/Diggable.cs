using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diggable : MonoBehaviour
{
    public enum SpriteState
    {
        Rock,
        Dirt,
        Sand
    }
    public SpriteState state;
    [SerializeField, Tooltip("Array containing different earth sprites")] private Sprite[] sprites;
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private GameObject particle;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (state)
        {
            case (SpriteState.Rock):
                spriteRenderer.sprite = sprites[0];
                break;
            
            case (SpriteState.Dirt):
                spriteRenderer.sprite = sprites[1];
                break;

            case (SpriteState.Sand):
                spriteRenderer.sprite = sprites[2];
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Instantiate(background, transform.position, transform.rotation);
            Instantiate(particle, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
