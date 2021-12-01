using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI totalCoinsUi;

    private long _totalCoins;
    private UIManager _uiManager;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            _uiManager = new UIManager(totalCoinsUi);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void addCoins(long coins)
    {
        _totalCoins += coins;
        _uiManager.UpdateCoins(_totalCoins);
    }

}
