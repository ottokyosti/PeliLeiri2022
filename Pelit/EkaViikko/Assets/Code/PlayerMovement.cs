using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField, Tooltip("A reference to the UI of the health parameter")] private GameObject healthSlider;

    private Vector2 moveDir;

    private bool move = false;

    [SerializeField]
    private StopMovement movement;

    [SerializeField]
    private float health = 3;

    private float origHealth;

    private GameStateManager gameStateManager;

    [SerializeField]
    private GameObject sprite;

    private bool isItUp;

    void Awake()
    {
        origHealth = health;
        gameStateManager = FindObjectOfType<GameStateManager>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnMoveUp(InputAction.CallbackContext callbackContext)
    {
        move = !move;
        if(callbackContext.performed)
        {
            moveDir = new Vector2(0F, 1F);
            gameObject.transform.up = new Vector3(0,0,0);
            sprite.transform.up = new Vector3(0,0,0);
            isItUp = true;
        }
    }

    private void OnMoveLeft(InputAction.CallbackContext callbackContext)
    {
        move = !move;
        if(callbackContext.performed && transform.position.x != -8.5f)
        {
            moveDir = new Vector2(-1F, 0F);
            gameObject.transform.up = new Vector3(-90,0,0);
            sprite.transform.up = new Vector3(0,0,0);
            sprite.GetComponent<SpriteRenderer>().flipX = true;
            isItUp = false;
        }
    }

    private void OnMoveRight(InputAction.CallbackContext callbackContext)
    {
        move = !move;
        if(callbackContext.performed && transform.position.x != 8.5f)
        {
            moveDir = new Vector2(1F, 0F);
            gameObject.transform.up = new Vector3(90,0,0);
            sprite.transform.up = new Vector3(0,0,0);
            sprite.GetComponent<SpriteRenderer>().flipX = false;
            isItUp = false;
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

    IEnumerator Punch()
    {
        yield return new WaitForSeconds(0.1F);
        GetComponentInChildren<Animator>().SetBool("punch_up", false);
        GetComponentInChildren<Animator>().SetBool("punch_side", false);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "lava")
        {
            gameStateManager.GameOver();
        }
        else if(col.gameObject.tag == "enemy")
        {
            if(isItUp)
            {
                GetComponentInChildren<Animator>().SetBool("punch_up", true);
            }
            else if(!isItUp)
            {
                GetComponentInChildren<Animator>().SetBool("punch_side", true);
            }
            StartCoroutine(Punch());
            health -= col.gameObject.GetComponent<Enemy>().health;
            healthSlider.GetComponent<Slider>().value--;

            if(health == 0)
            {
                gameStateManager.GameOver();
            }
        }
        else if(col.gameObject.tag == "powerup")
        {
            health = origHealth;
            healthSlider.GetComponent<Slider>().value = health;
        }
    }
}
