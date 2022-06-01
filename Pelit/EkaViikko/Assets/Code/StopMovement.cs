using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovement : MonoBehaviour
{

    public bool canMove = true;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "wall")
        {
            canMove = false;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.tag == "wall")
        {
            canMove = true;
        }
    }
}
