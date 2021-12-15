using Player;
using UnityEngine;

namespace Boss
{
    public class FrogBossDefeatedCutscene : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject arenaCenter;
        [SerializeField] private GameObject gameCompleteUI;

        private PlayerController _playerController;

        private bool _isCenterOfStage;

        private void Start()
        {
            _playerController = player.GetComponent<PlayerController>();
            _playerController.DisableControlsOnly();
        }

        private void Update()
        {
            if (_isCenterOfStage)
            {
                _playerController.UpdateMove(0);
                _playerController.Jump();
                gameCompleteUI.SetActive(true);
            }
            else
            {
                var arenaCenterPos = arenaCenter.transform.position;
                var playerPos = player.transform.position;
                var xDistanceToCenter = arenaCenterPos.x - playerPos.x;
                float playerMove = xDistanceToCenter > 0 ? 1 : -1;
                _playerController.UpdateMove(playerMove);
                if (xDistanceToCenter > -.1f && xDistanceToCenter < .1f)
                {
                    _isCenterOfStage = true;
                }

            }
        }
    }
}