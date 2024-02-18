using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Objects/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public int price;
    public Sprite itemGraphics;
    public Sprite shopIcon;
    public Slot slot;
}
