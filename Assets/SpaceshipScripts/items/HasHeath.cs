using UnityEngine;

namespace SpaceshipScripts
{
    public class HasHeath : MonoBehaviour
    {
        public int health = 10;
        private Destructible _destructible;
        private void Start()
        {
            _destructible = GetComponent<Destructible>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.CompareTag("anmo"))
            {
                return;
            }

            health--;
            if (health <= 0)
            {
                if (_destructible)
                {
                    _destructible.BreakIntoFragments();
                }
                Destroy(gameObject);
            }
        }
    }
}