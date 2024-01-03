using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    public void OnButton1Click()
    {
        // Xóa tất cả dữ liệu PlayerPref
        PlayerPrefs.DeleteAll();
    }

    public void OnButton2Click()
    {
        // Đặt giá trị của PlayerPref "InventoryCoins" thành 10000
        PlayerPrefs.SetInt("InventoryCoins", 10000);
    }

}
