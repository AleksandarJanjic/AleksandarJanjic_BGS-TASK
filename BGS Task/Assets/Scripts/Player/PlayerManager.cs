using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    [SerializeField] private PlayerInventory inventory;
    [SerializeField] private PlayerEquipement equipement;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public PlayerInventory GetPlayerInventory()
    {
        return inventory;
    }

    public PlayerEquipement GetPlayerEquipement()
    {
        return equipement;
    }
}
