using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    float bulletDamage;
    void Start(){}
    void Update(){}

    private void OnCollisionEnter2D(Collision2D collision)
    {

      //check whether an enemy is hit
      if (collision.gameObject.tag == "enemy")
      {
        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * 50, ForceMode2D.Impulse);

        // get the script that has the health variable
        collision.gameObject.GetComponent<Spider>().health -= bulletDamage;

        Destroy(gameObject);
      }
      // Destroy bullet if it hits any collider
      Destroy(gameObject);
    }

    public void setBulletDamage(float damage)
    {
      bulletDamage = damage;
    }






}
