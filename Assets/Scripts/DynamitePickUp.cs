using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamitePickUp : MonoBehaviour
{
    private static int amountOfDynamiteAdded = 2;
    private static int presentAmountOfDynamite;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");    
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == player)
        {
            player.GetComponent<PlayerWeapons>().AddAmountOfDynamites(amountOfDynamiteAdded);
            Destroy(gameObject);
        }
       
        
    }
}
