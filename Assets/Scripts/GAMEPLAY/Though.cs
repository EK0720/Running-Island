using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Though : MonoBehaviour
{
    public Button crossingButton;
    public PlayerThrough player;
    private int throughCount = 0;
    public Text throughText;
    [SerializeField] private GameObject ThroughUI;
    public TextMeshProUGUI countdownText; 
    private float countdownTimer = 4f; 
    private bool isCountingDown = false; 

    void Start()
    {
        throughCount = PlayerPrefs.GetInt("Through", 0);

        if (throughCount > 0)
        {
            crossingButton.onClick.AddListener(StartCrossing);
        }

        throughText.text = throughCount.ToString();
    }

    public void StartCrossing()
    {
        if (throughCount > 0 && !isCountingDown)
        {
            player.StartCrossing(4f);
            throughCount--;
            PlayerPrefs.SetInt("Through", throughCount);
            throughText.text = throughCount.ToString();

            ThroughUI.SetActive(true); 
            countdownTimer = 4f;
            isCountingDown = true;
        }
    }

    void Update()
    {
        if (isCountingDown)
        {
            countdownTimer -= Time.deltaTime;
            countdownText.text = Mathf.CeilToInt(countdownTimer).ToString();

            if (countdownTimer <= 0f)
            {
                ThroughUI.SetActive(false);
                isCountingDown = false;
            }
        }
    }
}