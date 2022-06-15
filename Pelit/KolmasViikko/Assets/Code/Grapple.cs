using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private bool m1Held = false;

    [SerializeField]
    private GameObject grapple;

    private GameObject grappleIns;

    private GameObject grappleHook;

    private Rigidbody2D rigidBody;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootGrapple();
        }
        if (Input.GetMouseButton(0))
        {
            m1Held = true;
            if (Input.GetMouseButtonDown(1))
            {
                PullPlayer();
            }
        }
        else if (!Input.GetMouseButton(0))
        {
            m1Held = false;
            this.transform.parent = null;
            Destroy(grappleIns);
        }
    }

    private void ShootGrapple()
    {
        grappleIns = Instantiate(grapple, (Vector2)transform.position, transform.rotation);
        this.gameObject.transform.SetParent(grappleIns.transform);
        grappleHook = grappleIns.transform.Find("Hook").gameObject;
    }

    private void PullPlayer()
    {
        rigidBody.AddForce((grappleHook.transform.position - transform.position).normalized * 1000);
    }
}
