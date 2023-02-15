using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public HitPoints hitPoints;
    public HealthBar healthBarPrefab;
    public Inventory inventoryPrefab;
    HealthBar healthBar;
    Inventory inventory;
     
    private void Start()
    {
        inventory = Instantiate(inventoryPrefab);
        healthBar = Instantiate(healthBarPrefab);
        healthBar.character = this;
        hitPoints.value = startingHitPoints;
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

    public override void ResetCharacter()
    { 
    
    }
    public override IEnumerator DamageCharacter(int damage, float interval)
    {
        while (true)
        {
            hitPoints.value = hitPoints.value - damage;
            if (hitPoints.value <= float.Epsilon)
            {
                KillCharacter();
                break;
            }

            if (interval > float.Epsilon)
            {
                yield return new WaitForSeconds(interval);
            }
            else
            {
                break;
            }
        }
    }

    public override void KillCharacter()
    {
        base.KillCharacter();
        Destroy(healthBar.gameObject);
        Destroy(inventory.gameObject);
    }
}
