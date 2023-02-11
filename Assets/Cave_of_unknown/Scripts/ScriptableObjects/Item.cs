using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//
[CreateAssetMenu(menuName = "Item")]

public class Item : ScriptableObject
{
    public string objectName;
    public Sprite sprite;
    public int quantitty;
    public bool stackable;
    public enum ItemType
    { 
        COIN, HEALTH
    }

    public ItemType itemType;
}
