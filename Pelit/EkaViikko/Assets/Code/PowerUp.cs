using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private GameObject background;
    [SerializeField] private GameObject soundEffect;
    [SerializeField] private Sprite[] itemBackgrounds;
    [SerializeField] private GameObject child;
    [SerializeField] private GameObject diggable;

    private void Start()
    {
        switch (diggable.GetComponent<Diggable>().state)
        {
            case (Diggable.SpriteState.Rock):
                child.GetComponent<SpriteRenderer>().sprite = itemBackgrounds[0];
                break;

            case (Diggable.SpriteState.Dirt):
                child.GetComponent<SpriteRenderer>().sprite = itemBackgrounds[1];
                break;

            case (Diggable.SpriteState.Sand):
                child.GetComponent<SpriteRenderer>().sprite = itemBackgrounds[2];
                break;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Instantiate(background, transform.position, transform.rotation);
            Instantiate(soundEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
