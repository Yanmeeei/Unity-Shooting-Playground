using UnityEngine;

namespace SpaceshipScripts
{
    public class HeadTurn : MonoBehaviour
    {
        public float rotationSpeed = 100f; 
        private float _targetRotation = 0f;  
        private float _originalRotation = 0f;

        [SerializeField] private SoldierMoveControl soldierMoveControl;

        private void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                _targetRotation = soldierMoveControl.targetScaleX * 45f;
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                _targetRotation = (-1) * soldierMoveControl.targetScaleX * 45f;
            }
            else
            {
                _targetRotation = _originalRotation;
            }

            var currentAngle = transform.eulerAngles.z;
            var newAngle = Mathf.MoveTowardsAngle(currentAngle, _targetRotation, rotationSpeed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, newAngle);
        }
    }
}