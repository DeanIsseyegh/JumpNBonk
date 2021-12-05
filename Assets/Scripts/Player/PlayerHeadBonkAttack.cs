using System;
using UnityEngine;

namespace Player
{
    public class PlayerHeadBonkAttack : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [SerializeField] private float headBonkBounceSpeed = 100;

        private void Awake()
        {
            _rb  = GetComponent<Rigidbody2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                _rb.AddForce(Vector2.up * headBonkBounceSpeed, ForceMode2D.Impulse);
            }
        }
    }
}
