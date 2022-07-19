using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveVelocity;
    [SerializeField] private float jumpVelocity;
    private Rigidbody2D rb2D;
    private bool isJumping;
    private float moveVertical;
    private float moveHorizontal;
    private float maxHorizontalVelocity;
    private Animator animator;
    private CheckpointSystem checkpointSystem;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        maxHorizontalVelocity = 7.7f;
        checkpointSystem = FindObjectOfType<CheckpointSystem>();
        if (checkpointSystem.currentCP != 0)
        {
            transform.position = checkpointSystem.checkpoints[checkpointSystem.currentCP - 1].transform.position;
            FindObjectOfType<CameraMovement>().gameObject.transform.position = new Vector3(transform.position.x, 2, -10);
        }
    }

    private void Update()
    {
        CheckPlayerInput();
        //Debug.Log(rb2D.velocity.magnitude);
        if (Input.GetKeyDown(KeyCode.E))
        {
            TextWriter.codeText.WriteText("gameObject.transform.right;");
        }
    }

    private void FixedUpdate()
    {
        UpdatePlayerMovement();
    }

    private void UpdatePlayerMovement()
    {
        Vector3 scale = transform.localScale;
        
        if (moveHorizontal > 0.1f)
        {
            //rb2D.velocity = Vector2.zero;
            rb2D.AddForce(new Vector2(moveHorizontal * moveVelocity, 0f), ForceMode2D.Impulse);
            scale.x = Mathf.Abs(scale.x);
            animator.SetBool("walking", true);
        }

        if (moveHorizontal < -0.1f)
        {
            //rb2D.velocity = Vector2.zero;
            rb2D.AddForce(new Vector2(moveHorizontal * moveVelocity, 0f), ForceMode2D.Impulse);
            scale.x = -(Mathf.Abs(scale.x));
            animator.SetBool("walking", true);
        }

        if (moveHorizontal == 0)
        {
            animator.SetBool("walking", false);
        }

        if (moveVertical > 0.1f && !(isJumping))
        {
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpVelocity), ForceMode2D.Impulse);
            isJumping = true;
        }
        
        var velocity = rb2D.velocity;

        if (velocity.x > maxHorizontalVelocity)
        {
            velocity.x = maxHorizontalVelocity;
        }

        if (velocity.x < -(maxHorizontalVelocity))
        {
            velocity.x = -(maxHorizontalVelocity);
        }
        rb2D.velocity = velocity;
        

        transform.localScale = scale;
    }

    private void CheckPlayerInput()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "floor")
        {
            isJumping = false;
        }
    }
}
