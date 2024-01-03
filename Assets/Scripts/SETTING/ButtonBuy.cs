using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBuy : MonoBehaviour
{
    private ITEMMANAGER ItemManager; // Tham chiếu đến ItemManager
    public GameObject StoreMenu;   
    // Start is called before the first frame update
    void Start()
    {
        // Tìm đối tượng ItemManager trong game
        ItemManager = StoreMenu.GetComponent<ITEMMANAGER>();

        // Thêm sự kiện click cho nút này
        this.gameObject.GetComponent<Button>().onClick.AddListener(() =>
        {
            // Kiểm tra xem nút có parent không
            if (transform.parent != null)
            {
                // Lấy tên của parent
                string parentName = transform.parent.name;

                // Gọi phương thức BuyItem() của ItemManager
                ItemManager.BuyItem(parentName);
            }
            else
            {
                // Nút không có parent, gọi BuyItem() với tên mặc định
                ItemManager.BuyItem("None");
            }
        });
    }
}