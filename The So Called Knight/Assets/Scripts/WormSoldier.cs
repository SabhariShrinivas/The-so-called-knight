using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSoldier : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Vector3 tempPos, tempScale;
    [Tooltip("Do not change")][SerializeField]private bool moveLeft;
    [SerializeField] private LayerMask groundLayer;
    private Transform groundCheckPos;
    [SerializeField] RaycastHit2D groundHit;
    private void Awake()
    {
        groundCheckPos = transform.GetChild(0);
        moveLeft = Random.Range(0,2) > 0 ? true : false;
    }

    private void Update()
    {
        HandleMovement();
        CheckForGround();
    }
    void HandleMovement()
    {
        tempPos = transform.position;
        tempScale = transform.localScale;
        if (moveLeft)
        {
            tempPos.x -= moveSpeed * Time.deltaTime;
            tempScale.x = -1f;
        }
        else
        {
            tempPos.x += moveSpeed * Time.deltaTime;
            tempScale.x = 1f;
        }
        transform.position = tempPos;
        transform.localScale = tempScale;
    }
    void CheckForGround()
    {
        groundHit = Physics2D.Raycast(groundCheckPos.position, Vector2.down, 0.5f, groundLayer);
        if (!groundHit) { moveLeft = !moveLeft; }
        Debug.DrawRay(groundCheckPos.position, Vector2.down * 0.5f, Color.red); ;
    }
}
