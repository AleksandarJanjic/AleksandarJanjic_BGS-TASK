using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICoinAmount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coins;

    void Start()
    {
        coins.text = PlayerManager.instance.GetPlayerInventory().GetCoinsAmount().ToString();
    }

    void OnEnable()
    {
        PlayerInventory.OnCoinsChange += UpdateCoins;
    }

    void OnDisable()
    {
        PlayerInventory.OnCoinsChange -= UpdateCoins;
    }

    private void UpdateCoins(int amount)
    {
        coins.text = amount.ToString();
    }
}
