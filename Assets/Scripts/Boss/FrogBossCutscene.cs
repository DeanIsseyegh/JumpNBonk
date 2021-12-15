using Cinemachine;
using Player;
using UnityEngine;

namespace Boss
{
    public class FrogBossCutscene : MonoBehaviour
    {

        [SerializeField] private GameObject player;
        [SerializeField] private FrogBossFight frogBoss;
        [SerializeField] private Animator stateDrivenCameraAnimator;
        [SerializeField] private GameObject arenaWalls;

        private BoxCollider2D _cutsceneTriggerCollider;
        private PlayerController _playerController;
        private Animator _playerAnimator;
        
        private static readonly int State = Animator.StringToHash("state");
        private SoundManager _soundManager;

        private void Awake()
        {
            _cutsceneTriggerCollider = GetComponent<BoxCollider2D>();
            _playerController = player.GetComponent<PlayerController>();
            _playerAnimator = player.GetComponent<Animator>();
            _soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _cutsceneTriggerCollider.enabled = false;
                StartFrogBossCutScene();
            }
        }

        private void StartFrogBossCutScene()
        {
            _soundManager.PlayBossMusic();
            _playerController.StopPlayerXVelocity();
            _playerController.Disable();
            _playerAnimator.SetInteger(State, (int) PlayerState.idle);
            stateDrivenCameraAnimator.Play("FrogBossCutsceneCamera");
            Invoke(nameof(StartBossFight), 1.5f);
        }

        private void StartBossFight()
        {
            arenaWalls.SetActive(true);
            stateDrivenCameraAnimator.Play("FrogBossFightCamera");
            _playerController.Enable();
            frogBoss.enabled = true;
        }
    }
}
