using System;
using System.Linq;
using Cinemachine;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerLife : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _playerRb;
        private BoxCollider2D _boxCollider2D;
        private PlayerController _playerController;
        private Animator _animator;

        [SerializeField] private CinemachineVirtualCamera _virtualCamera1;

        private void Start()
        {
            _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            _playerRb = gameObject.GetComponent<Rigidbody2D>();
            _boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
            _playerController = gameObject.GetComponent<PlayerController>();
            _animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Spike") || other.CompareTag("Enemy"))
            {
                OnDamaged();
            }
        }

        private void OnDamaged()
        {
            _playerController.Disable();
            _spriteRenderer.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.4f);
            _playerRb.velocity = new Vector2(0, 0);
            _playerRb.AddForce(Vector2.up * 600, ForceMode2D.Impulse);
            _boxCollider2D.enabled = false;
            _virtualCamera1.m_Follow = null;
            _animator.SetTrigger("death");
            Invoke(nameof(LoadGameOver), 1.5f);
        }

        private void LoadGameOver()
        {
            SceneLoader.LoadGameOverScreen();
        }
        
        
    }
}
