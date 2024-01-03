using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public Button product1Button;
    public Button product2Button;
    public Text priceText;
    public Text coinText;
    public Button buyProduct;
    public Button defaultButton;
    private int product1Price = 1000;
    private int product2Price = 2000;
    private int currentProduct; // Biến để lưu trữ sản phẩm hiện tại
    public GameObject  StoreMenu;

    private void Start()
    {
        // PlayerPrefs.DeleteAll();
        // PlayerPrefs.SetInt("InventoryCoins", 10000);

        product1Button.onClick.AddListener(() => ShowPriceAndSetCurrentProduct(product1Price, 1));
        product2Button.onClick.AddListener(() => ShowPriceAndSetCurrentProduct(product2Price, 2));

        int coin = PlayerPrefs.GetInt("InventoryCoins");
        coinText.text =  coin.ToString() + " $";

        // UpdateButtonInteractable();
        buyProduct.onClick.AddListener(() => BuyProduct());
    }

    public void ShowPriceAndSetCurrentProduct(int price, int product)
    {
        priceText.text = "Price: " + price.ToString();
        currentProduct = product; // Lưu trữ sản phẩm hiện tại
    if(product == 1){
        if (PlayerPrefs.GetInt("Product1Purchased") == 1)
    {
        priceText.text = "Purchased";
        // buyProduct.interactable = false;
    }
    }
    if (product == 2){
     if (PlayerPrefs.GetInt("Product2Purchased") == 1)
    {
        priceText.text = "Purchased";
        // buyProduct.interactable = false;

    }
    }

  
    }


    // public void UpdateButtonInteractable()
    // {
    //     int currentMoney = PlayerPrefs.GetInt("InventoryCoins");

    //     if (currentMoney >= product1Price && PlayerPrefs.GetInt("Product1Purchased") == 1)
    //     {
    //         buyProduct.interactable = false;
    //     }
    //     else
    //     {
    //         buyProduct.interactable = true;
    //     }
    //     if (currentMoney >= product2Price && PlayerPrefs.GetInt("Product2Purchased") == 1)
    //     {
    //         buyProduct.interactable = false;
    //     }
    //     else
    //     {
    //         buyProduct.interactable = true;
    //     }
    // }

    public void UpdateCoinText()
    {
        int coin = PlayerPrefs.GetInt("InventoryCoins");
        coinText.text = coin.ToString() + " $";
    }

    public void BuyProduct()
    {
        int currentMoney = PlayerPrefs.GetInt("InventoryCoins");

        if (currentProduct == 1 && currentMoney >= product1Price && PlayerPrefs.GetInt("Product1Purchased") != 1)
        {
            currentMoney -= product1Price;
            PlayerPrefs.SetInt("Product1Purchased", 1);
            if(PlayerPrefs.GetInt("Product1Purchased") == 1){
                priceText.text = "Purchased";
            }
            
        }
        else if (currentProduct == 2 && currentMoney >= product2Price && PlayerPrefs.GetInt("Product2Purchased") != 1)
        {
            currentMoney -= product2Price;
            PlayerPrefs.SetInt("Product2Purchased", 1);
            if(PlayerPrefs.GetInt("Product2Purchased") == 1){
                priceText.text = "Purchased";
            }
        }

        PlayerPrefs.SetInt("InventoryCoins", currentMoney);

        UpdateCoinText(); // Cập nhật lại giá trị coinText

        // UpdateButtonInteractable();
    }
    public void GoBack()
{
    if (currentProduct == 1 && PlayerPrefs.GetInt("Product1Purchased") != 1)
    {
        defaultButton.onClick.Invoke();
        SceneManager.LoadScene("Game");
    }
    else if (currentProduct == 2 && PlayerPrefs.GetInt("Product2Purchased") != 1)
    {
        defaultButton.onClick.Invoke();
        SceneManager.LoadScene("Game");
    }
    else  SceneManager.LoadScene("Game");

}
    public void exitshop(){
    UpdateCoinText();
    StoreMenu.SetActive(false);
    }
    public void openshop(){
    UpdateCoinText();
    StoreMenu.SetActive(true);
    }
}