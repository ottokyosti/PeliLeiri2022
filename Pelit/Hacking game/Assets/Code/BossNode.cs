using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNode : MonoBehaviour
{
    [SerializeField]
    private GameObject minion1;

    [SerializeField]
    private GameObject minion2;

    [SerializeField]
    private GameObject door;

    private CircleCollider2D hitbox;

    [SerializeField]
    private Sprite vulnerableSprite;

    [SerializeField]
    private Sprite destroyedSprite;

    public bool destroyed = false;

    private bool weakPointOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (minion1 == null && minion2 == null && !weakPointOpened)
        {
            weakPointOpened = true;
            OpenWeakPoint();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "crush")
        {
            hitbox.enabled = false;
            destroyed = true;
            GetComponent<SpriteRenderer>().sprite = destroyedSprite;
            OpenDoor();
        }
    }

    private void OpenWeakPoint()
    {
        GetComponent<SpriteRenderer>().sprite = vulnerableSprite;
        hitbox.enabled = true;
    }

    private void OpenDoor()
    {
        
    }
}
