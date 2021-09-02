using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockDelegate : MonoBehaviour
{
    [SerializeField] float scaleTime = 1f;
    private Vector3 myScale;
    private bool canScale;
    private BoxCollider2D myCollider;

    private void Awake()
    {
        myCollider = GetComponent<BoxCollider2D>();
    }
    private void OnEnable()
    {
        Key.keyCollectedInfo += UnlockDoor;
    }
    private void OnDisable()
    {
        
    }
    private void Update()
    {
        Unlock();
    }
    private void Unlock()
    {
        if (canScale)
        {
            myScale = transform.localScale;
            myScale.y -= scaleTime * Time.deltaTime;
            transform.localScale = myScale;
            if (transform.localScale.y <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    void UnlockDoor()
    {
        canScale = true;
    }
}
