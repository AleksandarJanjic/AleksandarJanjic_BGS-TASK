using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIIconController : MonoBehaviour
{
    [SerializeField] private GameObject icon;

    void OnEnable()
    {
        UIPlayerInventoryController.OnToggleButton += ToggleButton;
        ShopUIController.OnToggleButton += ToggleButton;
    }

    void OnDisable()
    {
        UIPlayerInventoryController.OnToggleButton -= ToggleButton;
        ShopUIController.OnToggleButton -= ToggleButton;
    }

    private void ToggleButton(bool toggle)
    {
        if(toggle)
        {
            icon.SetActive(true);
        } else 
        {
            icon.SetActive(false);
        }
    }
}
