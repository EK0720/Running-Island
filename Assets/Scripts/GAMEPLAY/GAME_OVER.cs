using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAME_OVER : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI CoinsCollected;

    private void Start()
    {
        int Highscore = PlayerPrefs.GetInt("Highscore", 0);
        if (PlayerPrefs.GetInt("Setx2Gold", 0) == 1)
        {
            CoinsCollected.text = PlayerPrefs.GetInt("CoinsCollected").ToString() + "x2";
            int coinsGet = PlayerPrefs.GetInt("CoinsCollected") * 2;
            PlayerPrefs.SetInt("CoinsCollected", coinsGet);
        }
        else
        {
            CoinsCollected.text = PlayerPrefs.GetInt("CoinsCollected").ToString();
        }
        int coin = PlayerPrefs.GetInt("CoinsCollected");
        if(coin > Highscore ){
            PlayerPrefs.SetInt("Highscore", coin);
        }
        
    }

    public void Retry()
    {
        PlayerPrefs.SetInt("Setx2Gold", 0);
        SceneManager.LoadScene("Game");
    
    }
}