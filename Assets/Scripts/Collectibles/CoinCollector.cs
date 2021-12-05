using TMPro;
using UnityEngine;

namespace Collectibles
{
    public abstract class CoinCollector : MonoBehaviour
    {
        protected int value;
        protected string collectibleName;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(collectibleName))
            {
                Destroy(other.gameObject);
                GameManager.Instance.AddCoins(value);
            }
        }
    }
}
