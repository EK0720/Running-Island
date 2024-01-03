using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserProfile : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Coin;
    public TextMeshProUGUI Hscore;

    void Start()
    {
        string PlayerName = PlayerPrefs.GetString("PlayerName", "");
        Name.text = "Name: " + PlayerName;
        
        int InventoryCoins = PlayerPrefs.GetInt("InventoryCoins", 0);
        Coin.text = "Coin: " + InventoryCoins.ToString();
        
        int Highscore = PlayerPrefs.GetInt("Highscore", 0);
        Hscore.text = "Highscore: " + Highscore.ToString();
    }

    void Update()
    {
        
    }
}