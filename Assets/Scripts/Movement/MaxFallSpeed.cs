using System;
using UnityEngine;

namespace Movement
{
    public class MaxFallSpeed : MonoBehaviour
    {
        [SerializeField] private float _maxFallSpeed;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_rb.velocity.y < -_maxFallSpeed)
            {
                _rb.velocity = new Vector2(_rb.velocity.x, -_maxFallSpeed);
            }
        }
    }
}