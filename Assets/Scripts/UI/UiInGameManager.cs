using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Singleton;

public class UiInGameManager : Singleton<UiInGameManager>
{
    public TextMeshProUGUI coinsCounterText;

    public TextMeshProUGUI lifeText;

    public static void UpdateUiCoins(string s) 
    {
        Instance.coinsCounterText.text = s;
    }

    public void UpdateUiLife(string l)
    {
        Instance.lifeText.text = l;
    }


}
