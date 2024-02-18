using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventorySelectedItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Image itemIcon;
    [SerializeField] private Button equipButton;

    // Broadcast that item has been equiped
    public delegate void ItemEquip(Item item);
    public static event ItemEquip OnItemEquip;

    public void SelectedItemSetup(Item item)
    {
        nameText.text = item.itemName;
        itemIcon.sprite = item.itemGraphics;
        equipButton.onClick.AddListener(() => EquipItem(item));
    }

    private void EquipItem(Item item)
    {
        OnItemEquip?.Invoke(item);
    }
}
