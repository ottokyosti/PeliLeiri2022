using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    private float origPositionX;
    [SerializeField] private float speed;
    [SerializeField] private float positionToGoTo;
    private Vector2 direction;

    private void Start()
    {
        origPositionX = transform.position.x;
        if (positionToGoTo < origPositionX)
        {
            direction = new Vector2(-1, 0);
        }
        else if (positionToGoTo > origPositionX)
        {
            direction = new Vector2(1, 0);
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        
        if (positionToGoTo < origPositionX)
        {
            if (transform.position.x <= positionToGoTo)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                direction = new Vector2(1, 0);
            }
        
            if (transform.position.x >= origPositionX)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                direction = new Vector2(-1, 0);
            }
        }
        else if (positionToGoTo > origPositionX)
        {
            if (transform.position.x >= positionToGoTo)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                direction = new Vector2(-1, 0);
            }
        
            if (transform.position.x <= origPositionX)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                direction = new Vector2(1, 0);
            }
        }
    }
}
