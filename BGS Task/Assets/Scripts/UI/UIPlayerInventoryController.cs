using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerInventoryController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject inventoryContent;
    [SerializeField] private GameObject inventoryItemPrefab;
    [SerializeField] private GameObject selectedItemGameObject;
    [SerializeField] private UIInventorySelectedItem selectedItemUI;
    private Item selectedItem;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            ShowInventory();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            HideInventory();
        }
    }

    public void ShowInventory()
    {
        animator.SetTrigger("Show");
        animator.ResetTrigger("Hide");

        PopulateInventory();
    }

    public void PopulateInventory()
    {
        List<Item> playerItems = PlayerManager.instance.GetPlayerInventory().GetPlayerItems();

        for(int i = 0; i < inventoryContent.transform.childCount; i++)
        {
            Destroy(inventoryContent.transform.GetChild(i).gameObject);
        }

        foreach(Item item in playerItems)
        {
            GameObject inventoryItem = Instantiate(inventoryItemPrefab, inventoryContent.transform);
            UIInventoryElement uiInventoryElement = inventoryItem.GetComponent<UIInventoryElement>();
            uiInventoryElement.GetItemImage().sprite = item.itemGraphics;
            uiInventoryElement.SetItemName(item.itemName);
            inventoryItem.GetComponent<Button>().onClick.AddListener(() => ItemClicked(uiInventoryElement.GetItemName()));
        }
    }

    public void HideInventory()
    {
        animator.SetTrigger("Hide");
        animator.ResetTrigger("Hide");
    }

    public void ItemClicked(string name)
    {
        Item item = PlayerManager.instance.GetPlayerInventory().GetPlayerItemByName(name);
        if(item != null)
        {
            selectedItem = item;
            selectedItemGameObject.SetActive(true);
            selectedItemUI.SelectedItemSetup(item);
        }
    }
}
