using System;
using UnityEngine;

namespace Movement
{
    public class StickyPlatform : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.transform.SetParent(transform);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                other.gameObject.transform.SetParent(null);
            }
        }
    }
}
