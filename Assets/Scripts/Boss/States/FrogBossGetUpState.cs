using UnityEngine;

namespace Boss.States
{
    public class FrogBossGetUpState : IFrogBossState
    {
        private readonly FrogBossStateCtx _ctx;
        private readonly int _facingDir;
        private bool _hasBegunGetUp;
        
        float _rotationAngle = 0;
        float _smoothTime = 3.0f;

        public FrogBossGetUpState(FrogBossStateCtx ctx, int facingDir)
        {
            _ctx = ctx;
            _facingDir = facingDir;
        }

        public void Update(float deltaTime)
        {
            if (!_hasBegunGetUp)
            {
                _ctx.Rb.AddForce(Vector2.up * 1000, ForceMode2D.Impulse);
                _hasBegunGetUp = true;
            }

            Quaternion desiredRotation = Quaternion.Euler (0,0,_rotationAngle);
            _ctx.Boss.transform.rotation = Quaternion.Lerp(_ctx.Boss.transform.rotation, desiredRotation, deltaTime * _smoothTime);
        }

        public void Transition(FrogBossFight frogBossFight)
        {
            Debug.Log(_ctx.Boss.transform.rotation.z);
            if (_ctx.Boss.transform.rotation.z > -0.002 && _ctx.Boss.transform.rotation.z < 0.002f)
            {
                int newDirToFace = FrogBossDirection.SwapDir(_facingDir);
                frogBossFight.Transition(new FrogBossRunToWallState(_ctx, newDirToFace));
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