using System;
using UnityEngine;

namespace Boss.States
{
    public class FrogBossRunToWallState : IFrogBossState
    {
        private readonly FrogBossStateCtx _ctx;
        private bool _isAtWall;

        private readonly int _facingDir;

        public FrogBossRunToWallState(FrogBossStateCtx ctx, int facingDir)
        {
            _ctx = ctx;
            _facingDir = facingDir;
        }

        public void Update(float deltaTime)
        {
            GameObject arenaWallToRunTo = _facingDir == FrogBossDirection.FacingLeft ? _ctx.ArenaWallRight : _ctx.ArenaWallLeft;
            float distanceFromWall = arenaWallToRunTo.transform.position.x - _ctx.Boss.transform.position.x;
            if (Math.Abs(distanceFromWall) > 3)
            {
                _ctx.SpriteRenderer.flipX = arenaWallToRunTo == _ctx.ArenaWallLeft;
                _ctx.Rb.AddForce(Vector2.right * -_facingDir * 100000 * deltaTime);
                _ctx.Animator.SetInteger("state", (int) FrogBossAnimationState.Running);
            }
            else
            {
                _ctx.Animator.SetInteger("state", (int) FrogBossAnimationState.Idle);
                _ctx.SpriteRenderer.flipX = arenaWallToRunTo != _ctx.ArenaWallLeft;
                _isAtWall = true;
            }
        }

        public void Transition(FrogBossFight frogBossFight)
        {
            if (_isAtWall)
            {
                frogBossFight.Transition(new FrogBossSawAttackState(_ctx, _facingDir));
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
        }
    }
}