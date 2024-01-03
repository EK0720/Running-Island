using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateMagnetPower : MonoBehaviour
{
    
    public Button MagnetButton;
    private int magnetCount; 
    public Text magnetText;

    void Start()
    {
        magnetCount = PlayerPrefs.GetInt("magnetCount", 0);
        if(magnetCount != null && magnetText != null){
            magnetText.text = magnetCount.ToString();
        }
    }

    public void StartMagnet()
    {
        if(magnetCount > 0){
        magnetCount--;
        MagnetPower.MagnetEnable = 1;
        PlayerPrefs.SetInt("magnetCount", magnetCount);
        }
    }

    void Update()
    {
        if(magnetCount != null && magnetText != null){
            magnetText.text = magnetCount.ToString();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        MagnetPower.MagnetEnable = 1;
        gameObject.SetActive(false);
    }
}
