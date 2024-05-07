using System;
using System.Collections;
using UnityEngine;

namespace SpaceshipScripts
{
    public class CanShine : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private float timer = 0f;
        private float timeToNextFlash = 0f;

        [SerializeField] private float flashTime = 0f;
        [SerializeField] public float flashInterval_left;
        [SerializeField] public float flashInterval_right;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                Debug.LogError("CanShine: No SpriteRenderer found on the GameObject.");
            }
            ResetTimer();
        }

        private void Update()
        {
            timer += Time.deltaTime;
            if (timer >= timeToNextFlash)
            {
                StartCoroutine(FlashSprite());
                ResetTimer();
            }
        }

        private IEnumerator FlashSprite()
        {
            Color color = spriteRenderer.color;
            color.a = 0f;
            spriteRenderer.color = color;
            
            yield return new WaitForSeconds(0.5f);
            
            color.a = 1f;
            spriteRenderer.color = color;
        }

        private void ResetTimer()
        {
            timeToNextFlash = UnityEngine.Random.Range(flashInterval_left, flashInterval_right);
            timer = 0f;
        }
    }
}