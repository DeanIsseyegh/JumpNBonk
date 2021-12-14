using UnityEngine;

namespace Boss
{
    public class FrogBossDefeatedCutscene : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject arenaCenter;
        
        private PlayerController _playerController;

        private bool _isCenterOfStage;

        private void Start()
        {
            _playerController = player.GetComponent<PlayerController>();
            _playerController.DisableControlsOnly();
        }

        private void Update()
        {
            if (!_isCenterOfStage)
            {
                var xDistanceToCenter = arenaCenter.transform.position.x - player.transform.position.x;
                if (xDistanceToCenter < .1f)
                {
                    _isCenterOfStage = true;
                }

                float dotToRight = Vector2.Dot(arenaCenter.transform.right, player.transform.right);
                _playerController.UpdateMove(dotToRight);
            }
            else
            {
                _playerController.UpdateMove(0);
                _playerController.Jump();
            }
        }
    }
}