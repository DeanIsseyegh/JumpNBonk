using System;
using UnityEngine;

namespace Player
{
    public class Checkpoint : MonoBehaviour
    {
        public static readonly Vector2 UnsetCheckpoint = Vector2.zero;

        private void Start()
        {
            var lastCheckpoint = GameManager.Instance.LastCheckPoint;
            if (lastCheckpoint != UnsetCheckpoint)
            {
                gameObject.transform.position = lastCheckpoint;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Checkpoint"))
            {
                GameManager.Instance.LastCheckPoint = other.gameObject.transform.position;
            }
        }
    }
}