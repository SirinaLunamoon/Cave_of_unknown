using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                        break;
                    case Item.ItemType.HEALTH:
                        AdjustHitPoints(hitObject.quantitty);
                        break;
                }

                //Destroy an object collide with the player
                collision.gameObject.SetActive(false);
            }
        }
    }

    public void AdjustHitPoints(int amount)
    { 
        hitPoints = hitPoints + amount;
        print("Nowe punkty: " + amount + ". Razem: " + hitPoints);
    }
}
