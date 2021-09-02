using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public static Lock instance;
    [SerializeField] private float ScaleTime = 1f;
    private Vector3 myScale;
    private bool canScale = false;
    private BoxCollider2D myCollider;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
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
            myScale.y -= ScaleTime * Time.deltaTime;
            transform.localScale = myScale;
            if(transform.localScale.y <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public void UnlockDoor()
    {
        canScale = true;
    }

}
