using UnityEngine;

namespace Boss.States
{
    public class FrogBossRunAttackState : IFrogBossState
    {
        private readonly FrogBossStateCtx _ctx;
        private float _timeSinceStartedAttacking;
        private float _attackLength = 4f;
        private float _restCountdown = 2f;
        private int _attacksLeft = 1;
        private int _facingDir;

        public FrogBossRunAttackState(FrogBossStateCtx ctx, int facingDir)
        {
            _ctx = ctx;
            _facingDir = facingDir;
        }
        
        public void Update(float deltaTime)
        {
            FacePlayer();
            if (_restCountdown > 0)
            {
                _ctx.Animator.SetInteger("state", (int) FrogBossAnimationState.Idle);
                _restCountdown -= deltaTime;
                _ctx.Rb.velocity = new Vector2(0, _ctx.Rb.velocity.y);
                return;
            }

            if (_timeSinceStartedAttacking < _attackLength)
            {
                _ctx.Animator.SetInteger("state", (int) FrogBossAnimationState.Running);
                _timeSinceStartedAttacking += deltaTime;
                int facingDir = IsPlayerToLeftOfBoss() ? FrogBossDirection.FacingLeft : FrogBossDirection.FacingRight;
                _ctx.Rb.AddForce(Vector2.right * facingDir * 100000 * deltaTime);
            }
            else
            {
                _timeSinceStartedAttacking = 0;
                _restCountdown = 2f;
                _attacksLeft--;
            }
        }

        private bool IsPlayerToLeftOfBoss()
        {
            return _ctx.Player.transform.position.x - _ctx.Boss.transform.position.x < 0;
        }

        public void Transition(FrogBossFight frogBossFight)
        {
            if (_attacksLeft <= 0)
            {
                frogBossFight.Transition(new FrogBossRunToWallState(_ctx, _facingDir));
            }
        }
        private void FacePlayer()
        {
            if (_ctx.Player.transform.position.x - _ctx.Boss.transform.position.x < 0)
            {
                _ctx.SpriteRenderer.flipX = true;
            }
            else
            {
                _ctx.SpriteRenderer.flipX = false;
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