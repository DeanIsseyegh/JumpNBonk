using System;
using UnityEngine;

namespace Boss.States
{
    public class FrogBossRageRunState : IFrogBossState
    {
        private readonly FrogBossStateCtx _ctx;
        private bool _isAtWall;

        private readonly int _facingDir;

        public FrogBossRageRunState(FrogBossStateCtx ctx, int facingDir)
        {
            _ctx = ctx;
            _facingDir = facingDir;
        }

        public void Update(float deltaTime)
        {
            GameObject arenaWallToRunTo = _facingDir == FrogBossDirection.FacingLeft ? _ctx.ArenaWallLeft : _ctx.ArenaWallRight;
            _ctx.SpriteRenderer.flipX = arenaWallToRunTo == _ctx.ArenaWallLeft;
            _ctx.Rb.AddForce(Vector2.right * _facingDir * 100000 * deltaTime);
            _ctx.Animator.SetInteger("state", (int) FrogBossAnimationState.Running);
        }

        public void Transition(FrogBossFight frogBossFight)
        {
            if (_isAtWall)
            {
                frogBossFight.Transition(new FrogBossFallDownState(_ctx, _facingDir));
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("ArenaWall"))
            {
                _isAtWall = true;
                _ctx.SoundManager.PlayRunIntoWallSound();
            }
        }
    }
}