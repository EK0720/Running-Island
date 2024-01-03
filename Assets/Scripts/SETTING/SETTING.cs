using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SETTING : MonoBehaviour
{
    public GameObject SettingMenu;
    [SerializeField] Slider volumeSlider;
    [SerializeField] AudioSource audioSource;
    public GameObject TutorialSetting;
    public GameObject UserProfile;
    public GameObject SoundMenu;
    public GameObject StoreMenu;
    public void ShowSettings()
    {
        SettingMenu.SetActive(true);
        Time.timeScale = 0f;
    }
     public void HideSettings()
    {
        SettingMenu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ShowTutorial()
    {
        TutorialSetting.SetActive(true);
    }
     public void HideTutorial()
    {
        TutorialSetting.SetActive(false);
    }
    public void ShowUserProfile()
    {
        UserProfile.SetActive(true);
    }
     public void HideUserProfile()
    {
        UserProfile.SetActive(false);
    }
        public void ShowSoundMenu()
    {
        SoundMenu.SetActive(true);
    }
     public void HideSoundMenu()
    {
        SoundMenu.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
     public void ChangeVolume()
    {
        audioSource.volume = volumeSlider.value;
    }
}
