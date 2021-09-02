using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangingSpike : MonoBehaviour
{
    private Rigidbody2D rB;
    [SerializeField] private LayerMask collisionLayer;
    [SerializeField] RaycastHit2D playerCast;
    private bool collidedWithPlayer;
    private void Awake()
    {
        rB = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        CheckForPlayerCollision();
    }
    void CheckForPlayerCollision()
    {
        if (collidedWithPlayer) { return; }
        playerCast = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, collisionLayer);
        if (playerCast)
        {
            rB.gravityScale = 2f;
            collidedWithPlayer = true;
        }
    }
}
