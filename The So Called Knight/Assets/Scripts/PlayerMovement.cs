using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sR;
    [SerializeField] float speed = 5f;
    [SerializeField] private float normalJumpForce = 5f, doubleJumpForce = 5f;
    private float jumpForce = 5f;
    private float horizontalMovement;
    private PlayerAnimation playerAnimation;
    private RaycastHit2D groundCast;
    private BoxCollider2D boxCol2D;
    [SerializeField] private LayerMask groundMask;
    private bool canDoubleJump, jumped;
    // Start is called before the first frame update
    void Start()
    {
        canDoubleJump = true;
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<PlayerAnimation>();
        boxCol2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        HandleJump();
        CheckToDoubleJump();
        FromJumpToWalkOrIdle();
    }
    private void FixedUpdate()
    {
        ProcessMovement();
        HandleAnimation();
       
    }
    private void ProcessMovement()
    {

        if (horizontalMovement > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            sR.flipX = false;
        }
        else if (horizontalMovement < 0)
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y);
            sR.flipX = true;
        }
        else
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }
    }
    private void HandleAnimation()
    {
        if(rb.velocity.y == 0) //if player is on ground
        {
            playerAnimation.PlayWalk((int)rb.velocity.x);
        }
        playerAnimation.PlayJumpAndFall((int)rb.velocity.y);
    }
    private void HandleJump()
    {

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                jumpForce = normalJumpForce;
                Jump();
            }
            else
            {
                if (canDoubleJump)
                {
                    Debug.Log("double jumped");
                    canDoubleJump = false;
                    jumpForce = doubleJumpForce;
                    Jump();
                }
            }
        }
    }

    bool IsGrounded()
    {
        //groundCast = Physics2D.Raycast(boxCol2D.bounds.center, Vector2.down, boxCol2D.bounds.extents.y + 0.3f, groundMask);
        //Debug.DrawRay(boxCol2D.bounds.center, Vector2.down * (boxCol2D.bounds.extents.y + 0.3f), Color.green);
        groundCast = Physics2D.BoxCast(boxCol2D.bounds.center, boxCol2D.bounds.size, 0f, Vector2.down, 0.01f, groundMask);

        return groundCast.collider != null;
    }
    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        jumped = true;
    }
    private void CheckToDoubleJump()
    {
        if(!canDoubleJump & rb.velocity.y == 0) { canDoubleJump = true; }
    }
    private void FromJumpToWalkOrIdle()
    {
        if (jumped && rb.velocity.y == 0)
        {
            jumped = false;
            if ((int)rb.velocity.x != 0)
            {
                playerAnimation.PlayAnimationWithName("walk");
            }
            else
            {
                playerAnimation.PlayAnimationWithName("idle");
            }
        }
    }
}
