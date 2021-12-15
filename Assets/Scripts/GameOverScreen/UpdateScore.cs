using TMPro;
using UnityEngine;

namespace GameOverScreen
{
    public class UpdateScore : MonoBehaviour
    {
        private TextMeshProUGUI _score;

        private void Start()
        {
            _score = GetComponent<TextMeshProUGUI>();
            _score.text = $"Score: {GameManager.Instance.TotalCoins}";
            GameManager.Instance.ResetCoins();
        }
    
    }
}
