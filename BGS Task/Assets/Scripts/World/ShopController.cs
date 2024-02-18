using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private List<Item> shopItems;

    public delegate void ShopUIDelegate(List<Item> shopItems);
    public static event ShopUIDelegate OnShopUISetup;
    public static event ShopUIDelegate OnShopUIRefresh;

    // Add item to player inventory
    public delegate void AddItemDelegate(Item item);
    public static event AddItemDelegate OnAddItem;

    // Remove item from players inventory
    public delegate void RemoveItemDelegate(Item item);
    public static event RemoveItemDelegate OnRemoveItem;

    // Change amount of coins in players inventory
    public delegate void ChangePlayerCoins(int amount);
    public static event ChangePlayerCoins OnAddCoins;
    public static event ChangePlayerCoins OnRemoveCoins;

    void OnEnable()
    {
        PlayerInteraction.OnShopOpen += SetupShopUI;
        ShopUIController.OnBuyItem += BuyItem;
        ShopUIController.OnSellItem += SellItem;
    }

    void OnDisable()
    {
        PlayerInteraction.OnShopOpen -= SetupShopUI;
        ShopUIController.OnBuyItem -= BuyItem;
        ShopUIController.OnSellItem -= SellItem;
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
        if(item != null && PlayerManager.instance.GetPlayerInventory().CheckEnoughCoins(item.price))
        {
            RemoveItemFromStore(item);
            OnAddItem?.Invoke(item);
            OnRemoveCoins?.Invoke(item.price);
            OnShopUIRefresh?.Invoke(shopItems);
        }
    }

    private void SellItem(string name)
    {
        Item item = PlayerManager.instance.GetPlayerInventory().GetPlayerItemByName(name);
        if(item != null)
        {
            AddItemToStore(item);
            OnRemoveItem?.Invoke(item);
            OnAddCoins?.Invoke(item.price);
            OnShopUIRefresh?.Invoke(shopItems);
        }
    }

    private void AddItemToStore(Item item)
    {
        shopItems.Add(item);
    }

    private void RemoveItemFromStore(Item item)
    {
        shopItems.Remove(item);
    }
}
