using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceshipScripts
{
    public class DestroyAfterTimePeriod : MonoBehaviour
    {
        public bool randomTime = false;
        
        [SerializeField] private float _timFix = 5f;
        [SerializeField] private float _timeMin = 5f;
        [SerializeField] private float _timeMax = 5f;

        private void Start()
        {
            var time = randomTime ? Random.Range(_timeMin, _timeMax) : _timFix;
            StartCoroutine(Timing(time));
        }

        private IEnumerator Timing(float time)
        {
            yield return new WaitForSeconds(time);
            Destroy(gameObject);
        } 
    }
}