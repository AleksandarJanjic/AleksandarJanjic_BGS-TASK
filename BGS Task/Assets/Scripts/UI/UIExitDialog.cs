using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIExitDialog : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void OnEnable()
    {
        UIManager.OnShowExit += Show;
    }

    void OnDisable()
    {
        UIManager.OnShowExit -= Show;
    }

    private void Show()
    {
        animator.SetTrigger("Show");
        animator.ResetTrigger("Hide");
    }

    private void Hide()
    {
        animator.SetTrigger("Hide");
        animator.ResetTrigger("Show");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Cancel()
    {
        Hide();
    }
}
