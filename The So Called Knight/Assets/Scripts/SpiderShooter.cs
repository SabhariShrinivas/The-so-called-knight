using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private Transform spawnPosition;
    [SerializeField] private float minShootTime = 2f, maxShootTime = 5f;

    private void Awake()
    {
        spawnPosition = transform.GetChild(0);
    }
    private void Start()
    {
        Invoke("ShootBullet", Random.Range(minShootTime, maxShootTime));
    }
    void ShootBullet()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        Invoke("ShootBullet", Random.Range(minShootTime, maxShootTime));
    }
}
