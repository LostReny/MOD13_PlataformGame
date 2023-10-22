using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollectManager : MonoBehaviour
{

    public static ItemCollectManager Instance;

    public int coins = 0;

    public TextMeshProUGUI coinsText;

    private void Awake() {

        if(Instance == null)
        Instance = this;
        else 
        Destroy(gameObject);
       
        coins = 0;
    }

    private void Update() {
        coinsText.text = "x " + coins; 
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
}
