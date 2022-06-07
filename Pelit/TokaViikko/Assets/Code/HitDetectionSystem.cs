using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetectionSystem : MonoBehaviour
{
    private GameObject clickedObject;

    private void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0);
        if (hitData && Input.GetMouseButtonDown(0))
        {
            clickedObject = hitData.transform.gameObject;
            //Here goes the code to decrease enemy hp, add score and so on...
        }
    }
}
