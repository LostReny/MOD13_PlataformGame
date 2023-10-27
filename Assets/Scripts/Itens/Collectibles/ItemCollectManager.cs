using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollectManager : MonoBehaviour
{

    public static ItemCollectManager Instance;

    public int coins = 0;

    public TextMeshProUGUI coinsCounterText;

    private void Awake() {

        if(Instance == null)
        Instance = this;
        else 
        Destroy(gameObject);
       
    }

    private void Update() {
        UpdateUi();
    }

    private void Start() {
        Reset();    
    }

    private void Reset() {
        AddCoins();
        coins = 0;
    }

    public void AddCoins(int amount = 1) {
        coins += amount;
    }

    public void UpdateUi()
    {
        coinsCounterText.text = "x " + coins;

    }
}
