using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    private Vector3 direction;
    private Rigidbody2D rigidBody;

    private LineRenderer line;

    private GameObject playerChar;

    public bool attached = false;

    // Start is called before the first frame update
    void Start()
    {
        playerChar = transform.parent.Find("playerChar").gameObject;
        direction = ((Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition)) - (Vector2)transform.position);
        rigidBody = GetComponent<Rigidbody2D>();
        Debug.Log(direction);
        Debug.Log(direction.normalized);
        rigidBody.AddForce(direction.normalized * 2000);
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, playerChar.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "can_grapple")
        {
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = 0;
            rigidBody.bodyType = RigidbodyType2D.Static;
            attached = true;
        }
    }
}

