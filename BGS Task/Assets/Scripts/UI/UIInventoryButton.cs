using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryButton : MonoBehaviour
{
    public delegate void InventoryButton();
    public static event InventoryButton OnInventoryButton;

    public void OpenInventory()
    {
        OnInventoryButton?.Invoke();
    }
}
