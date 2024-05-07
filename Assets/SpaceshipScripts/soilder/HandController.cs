using UnityEngine;

namespace SpaceshipScripts
{
    public class HandController : MonoBehaviour
    {
        private bool isEmpty = true;
        private GameObject GrabbedItem;

        public void AssignItemToHand(GameObject item)
        {
            GrabbedItem = item;
            isEmpty = false;
        }

        public void ReleaseItemFromHand()
        {
            GrabbedItem = null;
            isEmpty = true;
        }
        
        public bool IsEmpty()
        {
            return isEmpty;
        }

    }
}

