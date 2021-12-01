using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager
{

    private TextMeshProUGUI _totalCoins;
    
    public UIManager(TextMeshProUGUI totalCoins)
    {
        _totalCoins = totalCoins;
    }

    public void UpdateCoins(long totalCoins)
    {
        _totalCoins.SetText(totalCoins.ToString());
    }
}
