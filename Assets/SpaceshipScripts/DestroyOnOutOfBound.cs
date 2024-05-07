using System;
using UnityEngine;

namespace SpaceshipScripts
{
    public class DestroyOnOutOfBound : MonoBehaviour
    {
        private void Update()
        {
            if (Math.Abs(gameObject.transform.position.y) > 20) Destroy(gameObject);
            if (Math.Abs(gameObject.transform.position.x) > 100) Destroy(gameObject);
        }
    }
}