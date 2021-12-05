using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI totalCoinsText;

    public void UpdateCoins(long totalCoins)
    {
        totalCoinsText.SetText(totalCoins.ToString());
    }
}
