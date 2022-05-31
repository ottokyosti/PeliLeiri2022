using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDir;

    private bool move = false;

    void Update()
    {
        Debug.Log(moveDir);
    }

    private void OnMoveUp(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.performed)
        {
            moveDir = new Vector2(0F, 1F);
        }
    }

    private void OnMoveLeft(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.performed)
        {
            moveDir = new Vector2(-1F, 0F);
        }
    }

    private void OnMoveRight(InputAction.CallbackContext callbackContext)
    {
        if(callbackContext.performed)
        {
            moveDir = new Vector2(1F, 0F);
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
        gameObject.transform.position += (Vector3)moveDir.normalized;
    }
}
