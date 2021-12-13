using System;
using Boss;
using UnityEngine;

namespace Player
{
    public class PlayerHeadBonkAttack : MonoBehaviour
    {
        private Rigidbody2D _rb;
        [SerializeField] private float headBonkBounceSpeed = 100;
        private SoundManager _soundManager;

        private void Awake()
        {
            _rb  = GetComponent<Rigidbody2D>();
            _soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                DoHeadBonk();
                Destroy(other.gameObject);
            }
        }

        public void DoHeadBonk()
        {
            _soundManager.PlayHeadBonkSound();
            _rb.velocity =
                new Vector2(_rb.velocity.x, 0f); //reset jump velocity to avoid current jump/fall speed affecting next jump
            _rb.AddForce(Vector2.up * headBonkBounceSpeed, ForceMode2D.Impulse);
        }
    }
}
