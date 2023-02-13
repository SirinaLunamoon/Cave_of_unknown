using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //A reference to slotPrefab.
    public GameObject slotPrefab;
    public const int numSlots = 5;
    Image[] itemImages = new Image[numSlots];
    Item[] items = new Item[numSlots];
    GameObject[] slots = new GameObject[numSlots];

    // Start is called before the first frame update
    void Start()
    {
        CreateSlots();
    }

    public void CreateSlots()
    {
        //Is slotPrefab show in the Unity Editor?
        if (slotPrefab != null)
        {
            //Count an instances of slots prefabs
            for (int i = 0; i < numSlots; i++)
            {
                //Create an instance of slot prefab and assign it to newSlot
                GameObject newSlot = Instantiate(slotPrefab);
                newSlot.name = "ItemSlot_" + i;
                //Inventory object -> InventoryBg
                newSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);
                slots[i] = newSlot;
                //Slot -> ItemImage[1]
                itemImages[i] = newSlot.transform.GetChild(1).GetComponent<Image>();
            }
        }
    }

    //An item added to the inventory
    //If item is added correctly or not
    public bool AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items != null && items[i].itemType == itemToAdd.itemType && itemToAdd.stackable == true)
            {
                //Added more items to the inventory
                items[i].quantitty = items[i].quantitty + 1;
                //Create a GameObject and assign a script Slot to it
                Slot slotScript = slots[i].gameObject.GetComponent<Slot>();
                //A reference to the QtyText object.
                Text quantityText = slotScript.qtyText;
                //It shows us how many things is in the inventory
                quantityText.enabled = true;
                //It changes an integer to string and assign it to the QtyText
                quantityText.text = items[i].quantitty.ToString();
                //The item was added correctly to the inventory
                return true;
            }

            //if array items is empty there is added new item
            if (items[i] == null)
            {
                //Add item to empty place
                //Copy item and add to inventory
                items[i] = Instantiate(itemToAdd);
                items[i].quantitty = 1;
                itemImages[i].sprite = itemToAdd.sprite;
                //Add an item to the inventory
                itemImages[i].enabled = true;
                return true;
            }
        }
        //Inventory is full so anything wasn't add.
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}