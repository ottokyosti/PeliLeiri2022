using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipObject : MonoBehaviour
{
    public void FlipGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale *= -1;
    }
}
