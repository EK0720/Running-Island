using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ITEMMANAGER : MonoBehaviour
{
    public int magnetCost = 300;
    public int throughCost = 500;
    public int goldCost = 1000;
    public Text magnetText;
    public Text throughText;
    public Text goldText;
    public Text coinText;

    private Dictionary<string, int> itemCounts = new Dictionary<string, int>();
    private int coins;

    void Start()
    {
        LoadItemCounts();
        UpdateItemCountText();
    }

    private void LoadItemCounts()
    {
        // Load item counts from PlayerPrefs
        foreach (string itemName in PlayerPrefs.GetString("ItemNames", "").Split(','))
        {
            int count = PlayerPrefs.GetInt(itemName, 0);
            itemCounts.Add(itemName, count);
        }
        coins = PlayerPrefs.GetInt("InventoryCoins", 0);
    }

    private void SaveItemCounts()
    {
        // Save item counts to PlayerPrefs
        string itemNames = string.Join(",", itemCounts.Keys);
        PlayerPrefs.SetString("ItemNames", itemNames);
        foreach (KeyValuePair<string, int> itemCountPair in itemCounts)
        {
            PlayerPrefs.SetInt(itemCountPair.Key, itemCountPair.Value);
        }
        PlayerPrefs.SetInt("InventoryCoins", coins);
    }

    private void UpdateItemCountText()
    {
        magnetText.text = itemCounts.GetValueOrDefault("Magnet", 0).ToString();
        throughText.text = itemCounts.GetValueOrDefault("Through", 0).ToString();
        goldText.text = itemCounts.GetValueOrDefault("Gold", 0).ToString();
        coinText.text = coins.ToString() + " $";
    }

    public void BuyItem(string itemName)
    {
        int itemCost = 0;
        switch (itemName)
        {
            case "Magnet":
                itemCost = magnetCost;
                break;
            case "Through":
                itemCost = throughCost;
                break;
            case "Gold":
                itemCost = goldCost;
                break;
            default:
                Debug.LogError("Invalid item name: " + itemName);
                return;
        }

        if (coins >= itemCost)
        {
            // Subtract the cost from coin count
            coins -= itemCost;

            // Increase item count
            itemCounts[itemName] = itemCounts.GetValueOrDefault(itemName, 0) + 1;
            UpdateItemCountText();

            // Save updated counts
            SaveItemCounts();
        }
        else
        {
            // Handle insufficient funds
            Debug.Log("Not enough coins to buy " + itemName);
        }
    }
}
