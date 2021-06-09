using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthValue = 50;
    
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.name == "Player")
        {
            other.gameObject.GetComponent<PlayerMovement>().GetHealth(healthValue);
            Destroy(gameObject);
        }
    }


}
