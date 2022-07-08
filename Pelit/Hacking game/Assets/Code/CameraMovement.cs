using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float offSet;
    [SerializeField] private float offSetSmoothing;
    private Vector3 playerPosition;

    private void Update()
    {
        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offSet, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offSet, playerPosition.y, playerPosition.z);
        }
        
        transform.position = Vector3.Lerp(transform.position, playerPosition, offSetSmoothing * Time.deltaTime);
    }
}
