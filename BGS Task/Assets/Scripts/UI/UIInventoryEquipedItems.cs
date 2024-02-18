using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryEquipedItems : MonoBehaviour
{
    [SerializeField] List<EquipementSlotUI> equipementSlots;

    void OnEnable()
    {
        UIInventorySelectedItem.OnItemEquip += EquipItem;
        UIInventorySelectedItem.OnItemUneqip += UnequipItem;
        PlayerInventory.OnItemUneqip += UnequipItem;
    }

    void OnDisable()
    {
        UIInventorySelectedItem.OnItemEquip -= EquipItem;
        UIInventorySelectedItem.OnItemUneqip -= UnequipItem;
        PlayerInventory.OnItemUneqip -= UnequipItem;
    }

    public void UpdateEquipedItems()
    {
        List<EquipementSlot> equipedItems = PlayerManager.instance.GetPlayerEquipement().GetEquipedItems();
        for(int i = 0; i < equipedItems.Count; i++)
        {
            EquipItem(equipedItems[i].GetItem());
        }
    }

    public void EquipItem(Item item)
    {
        EquipementSlotUI slot = GetSlot(item);
        if(slot != null)
        {
            slot.SetItem(item);
        }
    }

    public void UnequipItem(Item item)
    {
        EquipementSlotUI equipementSlot = GetSlotByItemName(item.itemName);
        if(equipementSlot != null)
        {
            equipementSlot.RemoveItem(item);
        }
    }

    private EquipementSlotUI GetSlot(Item item)
    {
        foreach(EquipementSlotUI equipementSlot in equipementSlots)
        {
            if(equipementSlot.slot.Equals(item.slot))
            {
                return equipementSlot;
            }
        }
        return null;
    }

    private EquipementSlotUI GetSlotByItemName(string name)
    {
        foreach(EquipementSlotUI equipementSlot in equipementSlots)
        {
            if(equipementSlot.GetItem() != null && equipementSlot.GetItem().itemName.Equals(name))
            {
                return equipementSlot;
            }
        }
        return null;
    }

}

[System.Serializable]
public class EquipementSlotUI
{
    private Item equipedItem;
    public Slot slot;
    [SerializeField] private GameObject slotGraphicsParent;

    public void SetItem(Item item)
    {
        slotGraphicsParent.SetActive(true);
        equipedItem = item;
        Image image = slotGraphicsParent.GetComponent<Image>();
        image.sprite = item.itemGraphics;
    }

    public void RemoveItem(Item item)
    {
        equipedItem = null;
        Image image = slotGraphicsParent.GetComponent<Image>();
        image.sprite = null;
        slotGraphicsParent.SetActive(false);
    }

    public Item GetItem()
    {
        return equipedItem;
    }

    public bool isEquiped()
    {
        if(equipedItem != null)
        {
            return true;
        } else 
        {
            return false;
        }
    }
}
