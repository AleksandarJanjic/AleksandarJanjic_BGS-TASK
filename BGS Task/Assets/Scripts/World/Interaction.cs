using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private PlayerInteractionTarget playerInteraction;

    public delegate void PlayerInteracted(PlayerInteractionTarget? interationTarget);
    public static event PlayerInteracted OnPlayerInteracted;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider != null && collider.GetComponentInParent<PlayerMovement>())
        {
            OnPlayerInteracted?.Invoke(playerInteraction);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider != null && collider.GetComponentInParent<PlayerMovement>())
        {
            OnPlayerInteracted?.Invoke(null);
        }
    }
}
