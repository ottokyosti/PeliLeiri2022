using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField, Tooltip("Adjust how fast the camera goes upwards")] private float cameraSpeed;

    [SerializeField]
    private float moveTimer = 109;

    void Update()
    {
        moveTimer -= Time.deltaTime;
        if(moveTimer <= 0)
        {
            this.enabled = false;
        }
        transform.Translate(Vector2.up * Time.deltaTime * cameraSpeed);
    }
}
