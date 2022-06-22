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

    private bool facingLeft = true;
    private AudioSource audioSource;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(grappleIns == null)
            {
                ShootGrapple();
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (grappleHook.GetComponent<Hook>().attached && can_grapple)
            {
                PullPlayer();
                this.transform.parent = null;
                Destroy(grappleIns);
                can_grapple = true;
            }
            else
            {
                this.transform.parent = null;
                Destroy(grappleIns, 0.01f);
                can_grapple = true;
            }
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
        GetComponent<SpriteRenderer>().sprite = GetComponent<Player>().sprites[1];
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = 0;
        rigidBody.AddForce((grappleHook.transform.position - transform.position).normalized * 600);
        audioSource.Play();
        Debug.Log((grappleHook.transform.position - transform.position).normalized);
        if((grappleHook.transform.position - transform.position).normalized.x < 0 && !facingLeft)
        {
            Vector3 newScale = gameObject.transform.localScale;
            newScale.x *= -1;
            gameObject.transform.localScale = newScale;
            facingLeft = true;
        }
        else if((grappleHook.transform.position - transform.position).normalized.x > 0 && facingLeft)
        {
            Vector3 newScale = gameObject.transform.localScale;
            newScale.x *= -1;
            gameObject.transform.localScale = newScale;
            facingLeft = false;
        }
    }
}