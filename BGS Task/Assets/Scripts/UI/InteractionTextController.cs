using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionTextController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactionText;
    [SerializeField] private Animator animator;

    void OnEnable()
    {
        UIManager.OnInteractionText += ShowInteractionText;
    }

    void OnDisable()
    {
        UIManager.OnInteractionText -= ShowInteractionText;
    }

    private void ShowInteractionText(PlayerInteractionTarget? target)
    {
        if(target != null)
        {
            if(target == PlayerInteractionTarget.SHOP)
            {
                interactionText.text = "Press F to open Shop Menu";
            } else if(target == PlayerInteractionTarget.DOOR)
            {
                interactionText.text = "Leaving the shop not implemented";
            }
            animator.SetTrigger("Show");
            animator.ResetTrigger("Hide");
        } else 
        {
            animator.SetTrigger("Hide");
            animator.ResetTrigger("Show");
        }
    }
}

