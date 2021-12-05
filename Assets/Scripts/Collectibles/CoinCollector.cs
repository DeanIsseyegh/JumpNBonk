using System;
using TMPro;
using UnityEngine;

namespace Collectibles
{
    public abstract class CoinCollector : MonoBehaviour
    {
        protected int Value;
        protected string CollectibleName;
        private UIManager _uiManager;
        private SoundManager _soundManager;

        private void Awake()
        {
            _uiManager = GameObject.FindWithTag("UIManager").GetComponent<UIManager>();
            _soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(CollectibleName))
            {
                _soundManager.PlayCollectCoin();
                Destroy(other.gameObject);
                GameManager.Instance.AddCoins(_uiManager, Value);
            }
        }
    }
}
