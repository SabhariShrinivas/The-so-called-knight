using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBat : MonoBehaviour
{
    [SerializeField] private float moveSpeedHorizontal = 2f, moveSpeedVertical = -2f;
    [SerializeField] private float horizontalMovementThreshold = 7f, verticalMovementThreshold = 4f;
    private float minX, maxX, minY, maxY;
    private Vector3 tempPos;
    [SerializeField]private bool moveHorizontal = true;
    [SerializeField]private bool moveVertical = false;
    private SpriteRenderer sR;

    private void Awake()
    {
        minX = transform.position.x - horizontalMovementThreshold;
        maxX = transform.position.x + horizontalMovementThreshold;
        maxY = transform.position.y + verticalMovementThreshold;
        minY = transform.position.y - verticalMovementThreshold;
        sR = GetComponent<SpriteRenderer>();
        moveVertical = Random.Range(0, 2) > 0 ? true : false;
        if(Random.Range(0,2) > 0) { moveSpeedHorizontal *= -1f; }
     }
    private void Update()
    {
        HandleHorizontalMovement();
        HandleVerticalMovement();

        if(Random.Range(0,21) > 19)
        {
            ChangeDirection();
        }
    }
    void HandleHorizontalMovement()
    {
        if (moveHorizontal)
        {
            tempPos = transform.position;
            tempPos.x += moveSpeedHorizontal * Time.deltaTime;
            if(tempPos.x > maxX)
            {
                moveSpeedHorizontal = - Mathf.Abs(moveSpeedHorizontal);
            }
            if(tempPos.x < minX)
            {
                moveSpeedHorizontal = Mathf.Abs(moveSpeedHorizontal);
            }
            transform.position = tempPos;

            if(moveSpeedHorizontal < 0)
            {
                sR.flipX = true;
            }
            else
            {
                sR.flipX = false;
            }
        }
    }
    void HandleVerticalMovement()
    {
        if (moveVertical)
        {
            tempPos = transform.position;
            tempPos.y += moveSpeedVertical * Time.deltaTime;
            if (tempPos.y > maxY)
            {
                moveSpeedVertical = -Mathf.Abs(moveSpeedVertical);
            }
            if (tempPos.y < minY)
            {
                moveSpeedVertical = Mathf.Abs(moveSpeedVertical);
            }
            transform.position = tempPos;
        }
    }
    void ChangeDirection()
    {
        moveHorizontal = Random.Range(0, 2) > 0 ? true : false;
        moveVertical = Random.Range(0, 2) > 0 ? true : false;

    }

}
