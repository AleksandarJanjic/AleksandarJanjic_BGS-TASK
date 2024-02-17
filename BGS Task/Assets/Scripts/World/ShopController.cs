using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private List<Item> shopItems;

    public delegate void ShopUISetup(List<Item> shopItems);
    public static event ShopUISetup OnShopUISetup;

    // Add item to player inventory
    public delegate void AddItemDelegate(Item item);
    public static event AddItemDelegate OnAddItem;

    void OnEnable()
    {
        PlayerInteraction.OnShopOpen += SetupShopUI;
        ShopUIController.OnBuyItem += BuyItem;
    }

    void OnDisable()
    {
        PlayerInteraction.OnShopOpen -= SetupShopUI;
        ShopUIController.OnBuyItem -= BuyItem;
    }

    private void SetupShopUI()
    {
        OnShopUISetup?.Invoke(shopItems);
    }

    private Item GetItemByName(string name)
    {
        foreach(Item item in shopItems)
        {
            if(name.Equals(item.itemName))
            {
                return item;
            }
        }
        return null;
    }

    private void BuyItem(string name)
    {
        // Also deduct from player coin amount
        Item item = GetItemByName(name);
        if(item != null)
        {
            OnAddItem?.Invoke(item);
        }
    }
}
