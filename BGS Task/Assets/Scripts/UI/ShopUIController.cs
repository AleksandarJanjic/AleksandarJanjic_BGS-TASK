using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShopUIController : MonoBehaviour
{
    [SerializeField] private GameObject shopItemPrefab;
    [SerializeField] private GameObject shopContent;
    [SerializeField] private GameObject inventoryContent;
    [SerializeField] private Animator animator;

    public delegate void BuyItemDelegate(string itemName);
    public static event BuyItemDelegate OnBuyItem;

    void OnEnable()
    {
        ShopController.OnShopUISetup += ShopUISetup;
    }

    void OnDisable()
    {
        ShopController.OnShopUISetup -= ShopUISetup;
    }

    public void ShopUISetup(List<Item> shopItems)
    {
        animator.SetTrigger("Show");
        animator.ResetTrigger("Hide");

        PopulateShopItems(shopItems);
        PopulatePlayerItems();
    }

    public void PopulateShopItems(List<Item> shopItems)
    {
        // clear content child objects in case that shop item list has changed
        for(int i = 0; i < shopContent.transform.childCount; i++)
        {
            Destroy(shopContent.transform.GetChild(i).gameObject);
        }
        foreach(Item item in shopItems)
        {
            GameObject shopItem = Instantiate(shopItemPrefab, shopContent.transform);
            UIShopItem uiShopItem = shopItem.GetComponent<UIShopItem>();
            uiShopItem.SetItemName(item.itemName);
            uiShopItem.SetItemPrice(item.price);
            uiShopItem.SetButtonText(false);
            uiShopItem.SetItemIcon(item.itemGraphics);
            uiShopItem.GetButton().onClick.AddListener(() => BuyItem(item.itemName));
        }
    }

    public void PopulatePlayerItems()
    {
        for(int i = 0; i < inventoryContent.transform.childCount; i++)
        {
            Destroy(inventoryContent.transform.GetChild(i).gameObject);
        }

        List<Item> playerItems = PlayerManager.instance.GetPlayerInventory().GetPlayerItems();

        foreach(Item item in playerItems)
        {
            GameObject inventoryItem = Instantiate(shopItemPrefab, inventoryContent.transform);
            UIShopItem uiShopItem = inventoryItem.GetComponent<UIShopItem>();
            uiShopItem.SetItemName(item.itemName);
            uiShopItem.SetItemPrice(item.price);
            uiShopItem.SetButtonText(true);
            uiShopItem.SetItemIcon(item.itemGraphics);
        }
    }

    public void CloseShopUI()
    {
        animator.SetTrigger("Hide");
        animator.ResetTrigger("Show");
    }

    private void BuyItem(string itemName)
    {
        OnBuyItem?.Invoke(itemName);
    }

}
