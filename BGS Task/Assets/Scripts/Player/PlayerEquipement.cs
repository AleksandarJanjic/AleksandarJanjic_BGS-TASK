using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipement : MonoBehaviour
{
    [SerializeField] List<EquipementSlot> equipementSlots;

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

    public void EquipItem(Item item)
    {
        EquipementSlot slot = GetSlot(item);
        if(slot != null)
        {
            slot.SetItem(item);
        }
    }

    public void UnequipItem(Item item)
    {
        EquipementSlot equipementSlot = GetSlotByItemName(item.itemName);
        if(equipementSlot != null)
        {
            equipementSlot.RemoveItem(item);
        }
    }

    private EquipementSlot GetSlot(Item item)
    {
        foreach(EquipementSlot equipementSlot in equipementSlots)
        {
            if(equipementSlot.slot.Equals(item.slot))
            {
                return equipementSlot;
            }
        }
        return null;
    }

    public EquipementSlot GetSlotByItemName(string name)
    {
        foreach(EquipementSlot equipementSlot in equipementSlots)
        {
            if(equipementSlot.GetItem() != null && equipementSlot.GetItem().itemName.Equals(name))
            {
                return equipementSlot;
            }
        }
        return null;
    }

    public List<EquipementSlot> GetEquipedItems()
    {
        List<EquipementSlot> result = new List<EquipementSlot>();
        foreach(EquipementSlot slot in equipementSlots)
        {
            if(slot.isEquiped())
            {
                result.Add(slot);
            }
        }
        return result;
    }
}

[System.Serializable]
public class EquipementSlot
{
    private Item equipedItem;
    public Slot slot;
    [SerializeField] private GameObject slotGraphicsParent;

    public void SetItem(Item item)
    {
        equipedItem = item;
        SpriteRenderer renderer = slotGraphicsParent.GetComponent<SpriteRenderer>();
        renderer.sprite = item.itemGraphics;
    }

    public void RemoveItem(Item item)
    {
        equipedItem = null;
        SpriteRenderer renderer = slotGraphicsParent.GetComponent<SpriteRenderer>();
        renderer.sprite = null;
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

public enum Slot
{
    HEAD,
    HAND
}
