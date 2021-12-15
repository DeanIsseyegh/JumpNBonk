using Player;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public long TotalCoins { get; private set;  }
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
        TotalCoins += coins;
        uiManager.UpdateCoins(TotalCoins);
    }

    public void ResetCoins()
    {
        TotalCoins = 0;
    }
}
