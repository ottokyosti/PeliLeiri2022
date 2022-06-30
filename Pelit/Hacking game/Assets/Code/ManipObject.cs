using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipObject : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float force = 50;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void FlipGravity()
    {
        GetComponent<Rigidbody2D>().gravityScale *= -1;
    }

    public void ForceAdd()
    {
        if(player.transform.position.x <= gameObject.transform.position.x)
        {
            Debug.Log("forward");
            GetComponent<Rigidbody2D>().AddForce(new Vector3(1,0,0) * force);
        }
        else
        {
            Debug.Log("back");
            GetComponent<Rigidbody2D>().AddForce(new Vector3(-1,0,0) * force);   
        }
    }
}
