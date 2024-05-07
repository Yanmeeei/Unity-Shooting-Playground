using System;
using UnityEngine;

public class CanGrab : MonoBehaviour
{
    private GameObject objectToGrab;
    private Grabbable grabbedObjectScript;
    private AlexStatusManager _alexStatusManager;
    private bool grabbed;

    private void Awake()
    {
        _alexStatusManager = GetComponent<AlexStatusManager>();
        grabbed = false;
    }

    void Update()
    {
        if (_alexStatusManager.isGrabbing)
        {
            if (!grabbed && grabbedObjectScript == null)
            {
                // Attempt to grab the object
                if (objectToGrab != null)
                {
                    grabbedObjectScript = objectToGrab.GetComponent<Grabbable>();
                    if (grabbedObjectScript != null)
                    {
                        grabbedObjectScript.Grabbed(gameObject);
                        grabbed = true;
                    }
                }
            }
        }
        else if (grabbedObjectScript != null)
        {
            // Released the currently grabbed object
            grabbedObjectScript.Release();
            grabbedObjectScript = null;
            grabbed = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable") && objectToGrab == null)
        {
            objectToGrab = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == objectToGrab)
        {
            objectToGrab = null;
        }
    }
}