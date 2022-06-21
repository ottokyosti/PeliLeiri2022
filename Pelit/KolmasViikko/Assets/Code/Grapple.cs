using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    [SerializeField]
    private GameObject grapple;

    [SerializeField]
    private float grappleCooldown = 1.5f;

    private bool can_grapple = true;

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
            if (Input.GetMouseButtonDown(1) && grappleHook.GetComponent<Hook>().attached && can_grapple)
            {
                PullPlayer();
                StartCoroutine(Cooldown());
            }
            else if (Input.GetMouseButtonDown(1) && grappleHook.GetComponent<Hook>().enemy && can_grapple)
            {
                this.transform.parent = null;
                Destroy(grappleIns, 0.01f);
                can_grapple = true;
            }
        }
        else if (!Input.GetMouseButton(0))
        {
            this.transform.parent = null;
            Destroy(grappleIns);
            can_grapple = true;
        }
    }

    IEnumerator Cooldown()
    {
        can_grapple = false;
        yield return new WaitForSeconds(grappleCooldown);
        can_grapple = true;
    }

    private void ShootGrapple()
    {
        grappleIns = Instantiate(grapple, (Vector2)transform.position, transform.rotation);
        this.gameObject.transform.SetParent(grappleIns.transform);
        grappleHook = grappleIns.transform.Find("Hook").gameObject;
    }

    private void PullPlayer()
    {
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = 0;
        rigidBody.AddForce((grappleHook.transform.position - transform.position).normalized * 600);
    }
}