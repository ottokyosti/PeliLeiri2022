using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private Vector3 direction;
    private Rigidbody2D rigidBody;

    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(direction.normalized * 5000);
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(1, transform.position);
        line.SetPosition(2, transform.parent.transform.position);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "can_grapple")
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = 0;
        }
    }
}

