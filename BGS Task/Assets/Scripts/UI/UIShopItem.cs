using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShopItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] private Image iconImage;
    [SerializeField] private Button button;

    public void SetItemName(string name)
    {
        itemName.text = name;
    }

    public void SetItemPrice(int price)
    {
        priceText.text = "Cost: " + price.ToString();
    }

    public void SetButtonText(bool isPlayerItem)
    {
        if(isPlayerItem)
        {
            buttonText.text = "Sell";
        } else 
        {
            buttonText.text = "Buy";
        }
    }

    public void SetItemIcon(Sprite icon)
    {
        iconImage.sprite = icon;
    }

    public Button GetButton()
    {
        return button;
    }
}
