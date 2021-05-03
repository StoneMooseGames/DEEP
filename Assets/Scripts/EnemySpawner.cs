using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy; //drop enemy gameobject here
    Vector3 enemyLocation;

    // Start is called before the first frame update
    void Start()
    {
        //at start disable Spriterendering for this, because the sprite is there
        //only to mark the spot for the enemy.
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        //get the location for the enemy from gameobjects location
        enemyLocation = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y,0);
        //make a copy of the enemy gameobject and spawn it to the game into the enemylocation as a clone. Quaterion.identity marks the objects rotation
        Instantiate(enemy, enemyLocation, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
