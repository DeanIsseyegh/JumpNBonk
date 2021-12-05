using System;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI totalCoinsUi;

    private long _totalCoins;
    private UIManager _uiManager;

    public Vector2 LastCheckPoint { set; get; }

    private void Awake()
    {
        if (Instance == null)
        {
            LastCheckPoint = Checkpoint.UnsetCheckpoint;
            Instance = this;
            _uiManager = new UIManager(totalCoinsUi);
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddCoins(long coins)
    {
        _totalCoins += coins;
        _uiManager.UpdateCoins(_totalCoins);
    }

}
