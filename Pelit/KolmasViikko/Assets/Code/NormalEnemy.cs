using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    private Vector2 origPosition;
    [SerializeField] private float speed;
    [SerializeField] private bool turn;
    [SerializeField] private Vector2 positionToGoTo;

    private void Start()
    {
        origPosition = transform.position;
        Debug.Log(origPosition);
        if (turn)
        {
            MoveLeft();
        }
        else 
        {
            MoveRight();
        }
    }

    private void Update()
    {
        if (transform.position.x <= positionToGoTo.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            MoveRight();
        }
        
        if (transform.position.x >= origPosition.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            MoveLeft();
        }
    }

    private void MoveRight()
    {
        while (true)
        {
            transform.Translate(origPosition * speed * Time.deltaTime);
            if (transform.position.x >= origPosition.x)
            {
                break;
            }
        }
    }

    private void MoveLeft()
    {
        while (true)
        {
            transform.Translate(positionToGoTo * speed * Time.deltaTime);
            if (transform.position.x <= positionToGoTo.x)
            {
                break;
            }
        }
    }
}
