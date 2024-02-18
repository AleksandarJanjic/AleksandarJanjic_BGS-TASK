using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public delegate void InteractionText(PlayerInteractionTarget? target);
    public static event InteractionText OnInteractionText;

    public delegate void ShowExit();
    public static event ShowExit OnShowExit;

    private bool showExitDialog = true;

    void OnEnable()
    {
        Interaction.OnPlayerInteracted += ShowInteractionText;
        ShopUIController.OnToggleShowExit += ToggleShowExit;
        UIPlayerInventoryController.OnToggleShowExit += ToggleShowExit;
    }

    void OnDisable()
    {
        Interaction.OnPlayerInteracted -= ShowInteractionText;
        ShopUIController.OnToggleShowExit -= ToggleShowExit;
        UIPlayerInventoryController.OnToggleShowExit -= ToggleShowExit;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && showExitDialog)
        {
            OnShowExit?.Invoke();
        }
    }

    private void ToggleShowExit(bool toggle)
    {
        if(toggle)
        {
            showExitDialog = true;
        } else 
        {
            showExitDialog = false;
        }
    }

    private void ShowInteractionText(PlayerInteractionTarget? target)
    {
        OnInteractionText?.Invoke(target);
    }
}

public enum UIElementID
{
    INTERACTION_TEXT,
    SHOP
}
