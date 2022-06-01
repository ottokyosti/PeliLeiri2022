using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDir;

    private bool move = false;

    [SerializeField]
    private StopMovement movement;

    private void OnMoveUp(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.performed)
        {
            moveDir = new Vector2(0F, 1F);
            transform.up = new Vector3(0,0,0);
        }
    }

    private void OnMoveLeft(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.performed)
        {
            moveDir = new Vector2(-1F, 0F);
            transform.up = new Vector3(-90,0,0);
        }
    }

    private void OnMoveRight(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.performed)
        {
            moveDir = new Vector2(1F, 0F);
            transform.up = new Vector3(90,0,0);
        }
    }

    private void OnTunnel(InputAction.CallbackContext callbackContext)
    {
        move = !move;
        if(move)
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        if(movement.canMove)
        {
            gameObject.transform.position += (Vector3)moveDir.normalized;
        }
    }
}
