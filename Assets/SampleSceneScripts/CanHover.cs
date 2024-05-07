using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class CanHover : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private AlexStatusManager _alexStatusManager;
    private float speedFactor = 0.005f;
    private SpriteRenderer _spriteRenderer;
    private float yOffset = 0f;
    public float force = 6f;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        EventBus.Subscribe<StartStatusEvent>(OnStartStatusEvent);
        EventBus.Subscribe<EndStatusEvent>(OnEndStatusEvent);
    }

    private void FixedUpdate()
    {
        if (_alexStatusManager.isHovering)
        {
            Vector3 desiredAccel = new Vector3(0, force * force * (yOffset - rb.position.y), 0);
            rb.AddForce(desiredAccel, ForceMode.Acceleration);
        }
    }

    private void Update()
    {
        if (_alexStatusManager.isHovering)
        {
            yOffset += Input.GetAxis("Vertical") * speedFactor;
        }
    }

    private void OnStartStatusEvent(StartStatusEvent e)
    {
        if (e.status == AlexStatusManager.AlexStatus.Hover)
        {
            _spriteRenderer.color = Color.cyan;
            yOffset = rb.position.y;
            rb.velocity = Vector3.zero;
        }
    }

    private void OnEndStatusEvent(EndStatusEvent e)
    {
        if (e.status == AlexStatusManager.AlexStatus.Hover)
        {
            _spriteRenderer.color = Color.white;
        }
    }
}