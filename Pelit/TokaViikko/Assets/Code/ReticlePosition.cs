using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticlePosition : MonoBehaviour
{
    [SerializeField, Tooltip("Determines if the cursor is invisible or not")] private bool isCursorVisible;
    private void Start()
    {
        Cursor.visible = isCursorVisible;
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
    }
}
