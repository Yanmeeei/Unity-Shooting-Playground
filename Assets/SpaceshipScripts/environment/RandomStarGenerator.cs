using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceshipScripts
{
    public class RandomStarGenerator : MonoBehaviour
    {
        public bool canShine = true;
        public GameObject starPrefab; 
        public int numberOfStars;
        public float width; 
        public float height; 

        private void Start()
        {
            if (starPrefab == null)
            {
                Debug.LogError("RandomStarGenerator: No prefab assigned.");
                return;
            }

            GenerateStars();
        }

        [ContextMenu("Generate Stars")]
        private void GenerateStars()
        {
            for (var i = 0; i < numberOfStars; i++)
            {
                var x = Random.Range(-width / 2, width / 2);
                var y = Random.Range(-height / 2, height / 2);
                
                var spawnPosition = new Vector3(x, y, 0);
                spawnPosition += transform.position;

                var starInstance = Instantiate(starPrefab, spawnPosition, Quaternion.identity, transform);
                
                var randomScale = Random.Range(0.05f, 0.12f);
                starInstance.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

                var canShineComponent = starInstance.GetComponent<CanShine>();
                if (canShineComponent) canShineComponent.enabled = canShine;
                
                if (Random.Range(0, 100) < 80) continue;

                var color = Random.Range(0, 50) * 0.01f;
                starInstance.GetComponent<SpriteRenderer>().color = new Color(color,color,color);
            }
        }
        
        [ContextMenu("Clear Stars")]
        private void ClearStars()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
        
        [ContextMenu("Regenerate Stars")]
        private void Regenerate()
        {
            ClearStars();
            GenerateStars();
        }
    }
}