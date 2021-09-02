using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    private Animator anim;
    private float jumpForce;
    private Rigidbody2D myBody;
    private float jumpTimer;
    [SerializeField] private float minJumpTime = 2f, maxJumpTime = 5f;
    [SerializeField] private float minJumpForce = 5f, maxJumpForce = 10f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        jumpTimer = Time.time + Random.Range(minJumpTime, maxJumpTime);
    }
    private void Update()
    {
        if(Time.time > jumpTimer)
        {
            Jump();
        }
        if(myBody.velocity.y == 0)
        {
            anim.SetBool("Jump", false);
        }
    }
    void Jump()
    {
        jumpTimer = Time.time + Random.Range(minJumpTime, maxJumpTime);
        jumpForce = Random.Range(minJumpForce, maxJumpForce);
        myBody.velocity = new Vector2(0f, jumpForce);
        anim.SetBool("Jump", true);
    }
}
