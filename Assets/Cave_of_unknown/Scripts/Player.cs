using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public HealthBar healthBarPrefab;
    public Inventory inventoryPrefab;
    HealthBar healthBar;
    Inventory inventory;
     
    private void Start()
    {
        inventory = Instantiate(inventoryPrefab);
        
        hitPoints.value = startingHitPoints;
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Which object is collide with a player
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            //A reference to Item object and save it in hitObject.
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;
            if (hitObject != null) 
            { 
                print("Kolizja: " + hitObject.name);
                bool shouldDisappear = false;

                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        shouldDisappear = inventory.AddItem(hitObject);
                        break;
                    case Item.ItemType.HEALTH:
                        shouldDisappear = AdjustHitPoints(hitObject.quantitty);
                        break;
                        default: 
                        break;
                }

                if (shouldDisappear)
                { 
                    //Destroy an object collide with the player
                    collision.gameObject.SetActive(false);
                }
            }
        }
    }

    public bool AdjustHitPoints(int amount)
    {
        if (hitPoints.value < maxHitPoints)
        { 
            hitPoints.value = hitPoints.value + amount;
            print("Nowe punkty: " + amount + ". Razem: " + hitPoints.value);
            return true;
        }

        return false;
    }
}
