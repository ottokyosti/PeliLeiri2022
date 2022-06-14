using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{
    private bool m1Held = false;

    [SerializeField]
    private GameObject grapple;

    private GameObject grappleIns;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ShootGrapple();
        }
        if(Input.GetMouseButton(0))
        {
            m1Held = true;
        }
        else
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
    }
}
