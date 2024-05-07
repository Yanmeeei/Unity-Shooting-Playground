using System;
using Unity.VisualScripting;
using UnityEngine;

namespace SpaceshipScripts
{
    public class CanGrab : MonoBehaviour
    {
        [SerializeField] private GameObject leftHand;
        [SerializeField] private GameObject rightHand;

        private HandController leftHandController;
        private HandController rightHandController;
        
        public GameObject objectToGrab;
        private Grabbable grabbedObjectScript;

        private void Start()
        {
            leftHandController = leftHand.GetComponent<HandController>();
            rightHandController = rightHand.GetComponent<HandController>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (leftHandController.IsEmpty() && grabbedObjectScript == null)
                {
                    if (objectToGrab != null)
                    {
                        grabbedObjectScript = objectToGrab.GetComponent<Grabbable>();
                        if (grabbedObjectScript != null)
                        {
                            grabbedObjectScript.Grabbed(leftHand);
                            leftHandController.AssignItemToHand(objectToGrab);
                        }
                    }
                }
                else if (grabbedObjectScript != null)
                {
                    leftHandController.ReleaseItemFromHand();
                    grabbedObjectScript.Released();
                    grabbedObjectScript = null;
                }
            }
        }
    }
}