using UnityEngine;
using UnityEngine.UI;

public class PlayerNameManager : MonoBehaviour
{
    public InputField nameInput;
    public GameObject nameInputPanel;

    private void Start()
    {
        // Kiểm tra xem người chơi đã nhập tên hay chưa
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            Debug.Log("Xin chào, " + playerName);
            HideNameInputPanel();
        }
        else
        {
            ShowNameInputPanel();
        }
    }

    public void SavePlayerName()
    {
        string playerName = nameInput.text;

        // Lưu tên người chơi vào PlayerPrefs
        PlayerPrefs.SetString("PlayerName", playerName);
        Debug.Log("Tên người chơi đã được lưu.");

        // Ẩn ô nhập tên sau khi lưu tên thành công
        HideNameInputPanel();

        // Tiến hành các hoạt động sau khi lưu tên, ví dụ: chuyển sang màn hình chơi game
        // ...
    }

    private void HideNameInputPanel()
    {
        nameInputPanel.SetActive(false);
    }

    private void ShowNameInputPanel()
    {
        nameInputPanel.SetActive(true);
    }
        public void OnNameInputEndEdit()
    {
        SavePlayerName();
    }
}