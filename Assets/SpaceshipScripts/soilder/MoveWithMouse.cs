using System;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    public float radius = 0.5f;
    public Transform rotationCenter;
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 

        Vector3 direction = mousePosition - rotationCenter.position;
        direction.z = 0; 

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle = Mathf.Clamp(angle, -180, 180);
        
        float radian = angle * Mathf.Deg2Rad;
        Vector3 semicirclePosition = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0) * radius;
        transform.position = rotationCenter.position + semicirclePosition;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);
        transform.rotation = rotation;
    }
}