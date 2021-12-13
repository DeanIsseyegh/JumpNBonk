using UnityEngine;

namespace Boss.States
{
    public class FrogBossStateCtx
    {
        public GameObject Boss { get; }
        public Rigidbody2D Rb { get; }
        public Animator Animator { get; }
        public GameObject Player { get; }
        public SpriteRenderer SpriteRenderer { get; }
        public GameObject ArenaWallRight { get; }
        public GameObject ArenaWallLeft { get; }
        public GameObject ThrowingSaw { get; }
        public SoundManager SoundManager { get; }
        public int BossHp { get; private set; } = 1;

        public FrogBossStateCtx(GameObject boss, Rigidbody2D rb, Animator animator, GameObject player,
            SpriteRenderer spriteRenderer, GameObject arenaWallRight, GameObject arenaWallLeft, GameObject throwingSaw,
            SoundManager soundManager)
        {
            Boss = boss;
            Rb = rb;
            Animator = animator;
            Player = player;
            SpriteRenderer = spriteRenderer;
            ArenaWallRight = arenaWallRight;
            ArenaWallLeft = arenaWallLeft;
            ThrowingSaw = throwingSaw;
            SoundManager = soundManager;
        }

        public void ReduceBossHp()
        {
            BossHp -= 1;
        }

    }
}