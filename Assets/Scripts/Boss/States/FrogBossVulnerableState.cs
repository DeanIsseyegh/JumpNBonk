using Player;
using UnityEngine;

namespace Boss.States
{
    public class FrogBossVulnerableState : IFrogBossState
    {
        private readonly FrogBossStateCtx _ctx;
        private readonly int _facingDir;
        private readonly PlayerHeadBonkAttack _playerHeadBonkAttack;
        private bool _hasBeenHit;

        public FrogBossVulnerableState(FrogBossStateCtx ctx, int facingDir)
        {
            _ctx = ctx;
            _facingDir = facingDir;
            _playerHeadBonkAttack = _ctx.Player.GetComponent<PlayerHeadBonkAttack>();
            _ctx.Animator.SetInteger("state", (int) FrogBossAnimationState.Vulnerable);
        }

        public void Update(float deltaTime)
        {
        }

        public void Transition(FrogBossFight frogBossFight)
        {
            if (_hasBeenHit)
            {
                if (_ctx.BossHp <= 0)
                {
                    frogBossFight.KillBoss();
                }
                else
                {
                    frogBossFight.Transition(new FrogBossGetUpState(_ctx, _facingDir));
                }
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !_hasBeenHit)
            {
                _playerHeadBonkAttack.DoHeadBonk();
                _ctx.Animator.SetInteger("state", (int) FrogBossAnimationState.Idle);
                _hasBeenHit = true;
                _ctx.ReduceBossHp();
            }
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
        }
    }
}