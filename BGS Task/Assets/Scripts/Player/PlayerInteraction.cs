using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PlayerInteractionTarget? interactionTarget;

    public delegate void ShopUI();
    public static event ShopUI OnShopOpen;

    void OnEnable()
    {
        Interaction.OnPlayerInteracted += SetInteractionTarget;
    }

    void OnDisable()
    {
        Interaction.OnPlayerInteracted -= SetInteractionTarget;
    }

    private void SetInteractionTarget(PlayerInteractionTarget? target)
    {
        interactionTarget = target;
        Debug.Log("Interaction Target is: " + interactionTarget.ToString());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Pressed F");
            switch(interactionTarget)
            {
                case PlayerInteractionTarget.SHOP:
                    OnShopOpen?.Invoke();
                    break;
                case PlayerInteractionTarget.DOOR:
                    break;
                default:
                    break;
            }
        }
    }
}

public enum PlayerInteractionTarget
{
    SHOP,
    DOOR
}
