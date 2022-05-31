using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField, Tooltip("Adjust how fast the camera goes upwards")] private float cameraSpeed;

    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * cameraSpeed);
    }
}
