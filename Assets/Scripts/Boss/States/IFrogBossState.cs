using UnityEngine;

namespace Boss.States
{
    public interface IFrogBossState
    {
        void Update(float deltaTime);

        void Transition(FrogBossFight frogBossFight);

        void OnTriggerEnter2D(Collider2D other);
        void OnCollisionEnter2D(Collision2D other);
    }
}