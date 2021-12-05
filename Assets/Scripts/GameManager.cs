using Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private long _totalCoins;
    public Vector2 LastCheckPoint { set; get; }

    private void Awake()
    {
        if (Instance == null)
        {
            LastCheckPoint = Checkpoint.UnsetCheckpoint;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddCoins(UIManager uiManager, long coins)
    {
        _totalCoins += coins;
        uiManager.UpdateCoins(_totalCoins);
    }

    public void ResetCoins()
    {
        _totalCoins = 0;
    }
}
