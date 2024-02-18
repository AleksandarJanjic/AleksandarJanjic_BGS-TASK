using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryElement : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private string itemName;

    public Image GetItemImage()
    {
        return itemIcon;
    }

    public void SetItemName(string name)
    {
        itemName = name;
    }

    public string GetItemName()
    {
        return itemName;
    }
}
