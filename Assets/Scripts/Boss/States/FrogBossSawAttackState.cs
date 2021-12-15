using Movement;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Boss.States
{
    public class FrogBossSawAttackState : IFrogBossState
    {
        private readonly FrogBossStateCtx _ctx;
        private readonly int _facingDir;

        private float _sawAttackTimer = 1.5f;
        private SawAttack _lastSawAttack = SawAttack.NoAttack;
        private int _sawAttacksLeft = 2;

        public FrogBossSawAttackState(FrogBossStateCtx ctx, int facingDir)
        {
            _ctx = ctx;
            _facingDir = facingDir;
        }

        public void Update(float deltaTime)
        {
            if (_sawAttackTimer <= 0)
            {
                switch (_lastSawAttack)
                {
                    case SawAttack.LowAttack:
                        ThrowSawHigh();
                        break;
                    case SawAttack.HighAttack:
                        ThrowSawLow();
                        break;
                    case SawAttack.NoAttack:
                        ThrowSawLow();
                        break;
                }
            }
            else
            {
                _sawAttackTimer -= deltaTime;
            }
        }

        private void ThrowSawLow()
        {
            ThrowSaw(_ctx.Boss.transform.position);
        }

        private void ThrowSawHigh()
        {
            var bossPos = _ctx.Boss.transform.position;
            Vector2 highPosition = new Vector2(bossPos.x, bossPos.y + 1.5f);
            ThrowSaw(highPosition);
        }

        private void ThrowSaw(Vector2 sawPos)
        {
            float xBuffer = _facingDir * 1.5f;
            Vector2 sawPosWithBuffer = new Vector2(sawPos.x + xBuffer, sawPos.y);
            GameObject throwingSaw = Object.Instantiate(_ctx.ThrowingSaw, sawPosWithBuffer,
                _ctx.Boss.transform.rotation);
            Move sawMovement = throwingSaw.GetComponent<Move>();
            sawMovement.XDirection = _facingDir;
            sawMovement.XSpeed = 8;
            _ctx.SoundManager.PlayThrowingSawSound();
            _sawAttackTimer = 2.5f;
            _lastSawAttack = SawAttack.LowAttack;
            _sawAttacksLeft--;
        }

        public void Transition(FrogBossFight frogBossFight)
        {
            if (_sawAttacksLeft <= 0 && _sawAttackTimer <= 0)
            {
                frogBossFight.Transition(new FrogBossRageRunState(_ctx, _facingDir));
            } 
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
        }

        private enum SawAttack
        {
            NoAttack,
            LowAttack,
            HighAttack
        }
    }
}