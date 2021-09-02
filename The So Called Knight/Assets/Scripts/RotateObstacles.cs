using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObstacles : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 200f;
    private float zAngle;
    private void Update()
    {
        zAngle += rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(zAngle, Vector3.forward);
    }
}
