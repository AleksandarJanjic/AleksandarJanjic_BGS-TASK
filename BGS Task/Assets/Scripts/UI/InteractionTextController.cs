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
            animator.SetTrigger("Show");
            animator.ResetTrigger("Hide");
        } else 
        {
            animator.SetTrigger("Hide");
            animator.ResetTrigger("Show");
        }
    }
}

