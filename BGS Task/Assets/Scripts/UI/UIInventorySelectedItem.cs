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
    public static event ItemEquip OnItemUneqip;

    public void SelectedItemSetup(Item item)
    {
        nameText.text = item.itemName;
        itemIcon.sprite = item.itemGraphics;
        itemIcon.preserveAspect = true;
        if(PlayerManager.instance.GetPlayerEquipement().GetSlotByItemName(item.itemName) != null)
        {
            ClearListeners();
            equipButton.onClick.AddListener(() => UnequipItem(item));
            equipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Unequip";
        } else 
        {
            ClearListeners();
            equipButton.onClick.AddListener(() => EquipItem(item));
            equipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
        }
    }

    private void EquipItem(Item item)
    {
        OnItemEquip?.Invoke(item);
        ClearListeners();
        equipButton.onClick.AddListener(() => UnequipItem(item));
        equipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Unequip";
    }

    private void UnequipItem(Item item)
    {
        OnItemUneqip?.Invoke(item);
        ClearListeners();
        equipButton.onClick.AddListener(() => EquipItem(item));
        equipButton.GetComponentInChildren<TextMeshProUGUI>().text = "Equip";
    }

    private void ClearListeners()
    {
        equipButton.onClick.RemoveAllListeners();
    }
}
