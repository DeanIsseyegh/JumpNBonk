using System;
using System.Linq;
using Boss.States;
using UnityEngine;

namespace Boss
{
    public class FrogBossFight : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject arenaWallRight;
        [SerializeField] private GameObject arenaWallLeft;
        [SerializeField] private GameObject throwingSaw;
        private Rigidbody2D _rb;
        private SpriteRenderer _renderer;
        private Animator _animator;

        private IFrogBossState _frogBossState;
        private FrogBossStateCtx _frogBossStateCtx;

        private bool _isBossDead;
        private SoundManager _soundManager;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _renderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
            _soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
            _frogBossStateCtx = new FrogBossStateCtx(gameObject, _rb, _animator, player, _renderer, arenaWallRight, arenaWallLeft, throwingSaw, _soundManager);
            _frogBossState = new FrogBossRunAttackState(_frogBossStateCtx, FrogBossDirection.FacingLeft);
        }

        private void Update()
        {
            if (_isBossDead) return;
            _frogBossState.Transition(this);
            _frogBossState.Update(Time.deltaTime); 
        }

        public void Transition(IFrogBossState state)
        {
            _frogBossState = state;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _frogBossState.OnTriggerEnter2D(other);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _frogBossState.OnCollisionEnter2D(other);
        }

        public void KillBoss()
        {
            _isBossDead = true;
            _rb.AddForce(Vector2.up * 800, ForceMode2D.Impulse);
            _renderer.color = new Color(Color.red.r, Color.red.g, Color.red.b, 0.4f);
             gameObject.GetComponents<BoxCollider2D>().ToList().ForEach(it => it.enabled = false);
             _soundManager.PlayGameCompleteMusic();
        }
        
    }
}