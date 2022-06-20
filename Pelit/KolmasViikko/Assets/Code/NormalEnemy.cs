using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    private float origPositionX;
    [SerializeField] private float speed;
    private bool turn;
    [SerializeField] private float positionToGoTo;

    private void Start()
    {
        origPositionX = transform.position.x;
    }

    private void Update()
    {
        if (turn)
        {
            transform.Translate(new Vector2(origPositionX, 0) * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector2(positionToGoTo, 0) * speed * Time.deltaTime);
        }
        
        if (positionToGoTo < origPositionX)
        {
            if (transform.position.x <= positionToGoTo)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                turn = true;
            }
        
            if (transform.position.x >= origPositionX)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                turn = false;
            }
        }
        else if (positionToGoTo > origPositionX)
        {
            if (transform.position.x >= positionToGoTo)
            {
                GetComponent<SpriteRenderer>().flipX = false;
                turn = true;
            }
        
            if (transform.position.x <= origPositionX)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                turn = false;
            }
        }
    }
}
