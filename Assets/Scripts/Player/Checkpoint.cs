using System;
using UnityEngine;

namespace Player
{
    public class Checkpoint : MonoBehaviour
    {
        public static readonly Vector2 UnsetCheckpoint = Vector2.zero;
        private SoundManager _soundManager;

        private void Start()
        {
            _soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
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
                var o = other.gameObject;
                GameManager.Instance.LastCheckPoint = o.transform.position;
                _soundManager.PlayCheckpointSound();
                Destroy(o);
            }
        }
    }
}