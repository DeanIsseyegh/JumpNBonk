using Movement;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Boss.States
{
    public class FrogBossFallDownState : IFrogBossState
    {
        private readonly FrogBossStateCtx _ctx;
        private readonly int _facingDir;
        private bool _hasBegunFallDown;

        private readonly Quaternion _desiredRotation;
        float _smoothTime = 3.0f;

        public FrogBossFallDownState(FrogBossStateCtx ctx, int facingDir)
        {
            _ctx = ctx;
            _facingDir = facingDir;
            _desiredRotation = Quaternion.Euler(0, 0, -180 * _facingDir);
        }

        public void Update(float deltaTime)
        {
            if (!_hasBegunFallDown)
            {
                _ctx.Rb.AddForce(Vector2.up * 1000, ForceMode2D.Impulse);
                _hasBegunFallDown = true;
            }

            _ctx.Boss.transform.rotation = Quaternion.Lerp(_ctx.Boss.transform.rotation, _desiredRotation, deltaTime * _smoothTime);
        }

        public void Transition(FrogBossFight frogBossFight)
        {
            if (_ctx.Boss.transform.rotation.z > -1.001f && _ctx.Boss.transform.rotation.z < -0.999f)
            {
                _ctx.Boss.transform.rotation = _desiredRotation;
                frogBossFight.Transition(new FrogBossVulnerableState(_ctx, _facingDir));
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