using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockChildRotate : MonoBehaviour
{
    Quaternion initRotation;

    private void Start()
    {
        initRotation = new Quaternion(0, 0, 0, 1);
    }

    private void LateUpdate()
    {
        transform.rotation = initRotation;
    }
}
