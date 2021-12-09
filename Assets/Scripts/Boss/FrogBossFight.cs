using System;
using UnityEngine;

namespace Boss
{
    public class FrogBossFight : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private Rigidbody2D _rigidbody2D;
        private float _timeSinceLastMove = 999f;
        private float _moveFrequency = 2.5f;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _timeSinceLastMove += Time.deltaTime;
            if (_timeSinceLastMove < _moveFrequency) return;
            
            int facingDir = 1;
            if (player.transform.position.x - transform.position.x < 0)
            {
                facingDir = -1;

            }
            _rigidbody2D.AddForce(Vector2.right * facingDir * 10, ForceMode2D.Impulse);
            _timeSinceLastMove = 0;
        }
    }
}
