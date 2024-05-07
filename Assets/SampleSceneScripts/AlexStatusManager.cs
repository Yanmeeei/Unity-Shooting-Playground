using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AlexStatusManager : MonoBehaviour
{
    public enum AlexStatus
    {
        Hover,
        Grab
    }
    
    public bool isHovering;
    public bool isGrabbing;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHovering = !isHovering;
            if (isHovering)
            {
                EventBus.Publish(new StartStatusEvent(AlexStatus.Hover));
            }
            else
            {
                EventBus.Publish(new EndStatusEvent(AlexStatus.Hover));
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            isGrabbing = !isGrabbing;
            if (isGrabbing)
            {
                _spriteRenderer.color = Color.yellow;
            }
            else
            {
                _spriteRenderer.color = Color.white;
            }
        }
    }
}

public class StartStatusEvent
{
    public AlexStatusManager.AlexStatus status;

    public StartStatusEvent(AlexStatusManager.AlexStatus _s)
    {
        status = _s;
    }
}

public class EndStatusEvent
{
    public AlexStatusManager.AlexStatus status;

    public EndStatusEvent(AlexStatusManager.AlexStatus _s)
    {
        status = _s;
    }
}