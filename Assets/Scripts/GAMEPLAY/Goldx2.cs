using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goldx2 : MonoBehaviour
{
    public Button BoldButton;
    private int goldCount;
    private int Setx2Gold;

    public Text goldText;

    void Start()
    {
        goldCount = PlayerPrefs.GetInt("Gold", 0);
        Setx2Gold = PlayerPrefs.GetInt("Setx2Gold", 0);
        goldText.text = goldCount.ToString();
    }

    public void Startx2Gold()
    {
        if (Setx2Gold !=1 && goldCount > 0)
        {
            goldCount --;
            PlayerPrefs.SetInt("Gold", goldCount);
            PlayerPrefs.SetInt("Setx2Gold", 1);
        }
    }

    void Update()
    {
        goldText.text = goldCount.ToString();
    }
}