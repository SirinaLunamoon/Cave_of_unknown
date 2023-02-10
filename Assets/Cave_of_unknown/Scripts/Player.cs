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
            //Destroy an object collide with the player
            collision.gameObject.SetActive(false);
        }
    }
}
