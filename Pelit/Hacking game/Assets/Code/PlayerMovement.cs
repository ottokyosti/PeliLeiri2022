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
    private AudioSource[] audioSources;

    private void Start()
    {
        audioSources = GetComponentsInChildren<AudioSource>();
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
            rb2D.AddForce(new Vector2(moveHorizontal * moveVelocity, 0f), ForceMode2D.Impulse);
            scale.x = Mathf.Abs(scale.x);
            if (!isJumping)
            {
                animator.SetBool("walking", true);
            }
            if (!(audioSources[2].isPlaying) && !(isJumping))
            {
                audioSources[2].Play();
            }
        }

        if (moveHorizontal < -0.1f)
        {
            rb2D.AddForce(new Vector2(moveHorizontal * moveVelocity, 0f), ForceMode2D.Impulse);
            scale.x = -(Mathf.Abs(scale.x));
            if (!isJumping)
            {
                animator.SetBool("walking", true);
            }
            if (!(audioSources[2].isPlaying) && !(isJumping))
            {
                audioSources[2].Play();
            }
        }

        if (moveHorizontal == 0)
        {
            animator.SetBool("walking", false);
            audioSources[2].Stop();
        }

        if (moveVertical > 0.1f && !(isJumping))
        {
            animator.SetBool("walking", false);
            animator.SetBool("jumping", true);
            rb2D.AddForce(new Vector2(0f, moveVertical * jumpVelocity), ForceMode2D.Impulse);
            audioSources[2].Stop();
            audioSources[1].Play();
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
            animator.SetBool("jumping", false);
            isJumping = false;
        }
    }
}
