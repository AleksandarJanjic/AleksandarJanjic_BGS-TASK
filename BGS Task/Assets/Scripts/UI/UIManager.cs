using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public delegate void InteractionText(PlayerInteractionTarget? target);
    public static event InteractionText OnInteractionText;

    void OnEnable()
    {
        Interaction.OnPlayerInteracted += ShowInteractionText;
    }

    void OnDisable()
    {
        Interaction.OnPlayerInteracted -= ShowInteractionText;
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
