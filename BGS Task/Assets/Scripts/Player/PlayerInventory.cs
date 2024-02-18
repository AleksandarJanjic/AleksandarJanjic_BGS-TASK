using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<Item> items;
    [SerializeField] private int goldCoins;

    public delegate void ItemEquip(Item item);
    public static event ItemEquip OnItemUneqip;

    public delegate void CoinsChange(int newAmount);
    public static event CoinsChange OnCoinsChange;

    void OnEnable()
    {
        ShopController.OnAddItem += AddItem;
        ShopController.OnRemoveItem += RemoveItem;
        ShopController.OnAddCoins += AddCoins;
        ShopController.OnRemoveCoins += RemoveCoins;
    }

    void OnDisable()
    {
        ShopController.OnAddItem -= AddItem;
        ShopController.OnRemoveItem -= RemoveItem;
        ShopController.OnAddCoins -= AddCoins;
        ShopController.OnRemoveCoins -= RemoveCoins;
    }

    public List<Item> GetPlayerItems()
    {
        return items;
    }

    public Item GetPlayerItemByName(string name)
    {
        foreach(Item item in items)
        {
            if(name.Equals(item.itemName))
            {
                return item;
            }
        }
        return null;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        if(PlayerManager.instance.GetPlayerEquipement().GetSlotByItemName(item.itemName) != null && PlayerManager.instance.GetPlayerEquipement().GetSlotByItemName(item.itemName).isEquiped())
        {
            OnItemUneqip?.Invoke(item);
        }
        items.Remove(item);
    }

    public bool CheckEnoughCoins(int amount)
    {
        if(amount <= goldCoins)
        {
            return true;
        } else {
            return false;
        }
    }

    public int GetCoinsAmount()
    {
        return goldCoins;
    }

    public void AddCoins(int amount)
    {
        goldCoins += amount;
        OnCoinsChange?.Invoke(goldCoins);
    }

    public void RemoveCoins(int amount)
    {
        goldCoins -= amount;
        OnCoinsChange?.Invoke(goldCoins);
    }
}
