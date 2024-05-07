using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CanFlash : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private AlexMoveControl _alexMoveControl;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            rb.position += _alexMoveControl.forwardDir * 5;
        }
    }
    
}