using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField]
    private List<Item> items;

    void OnEnable()
    {
        ShopController.OnAddItem += AddItem;
    }

    void OnDisable()
    {
        ShopController.OnAddItem -= AddItem;
    }

    public List<Item> GetPlayerItems()
    {
        return items;
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);
    }
}
