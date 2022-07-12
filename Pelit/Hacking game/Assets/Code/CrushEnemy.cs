using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushEnemy : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
