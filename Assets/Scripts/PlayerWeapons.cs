using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    public GameObject bulletPrefab; // drop bullet prefab here
    public GameObject dynamitePrefab;
    Vector2 playerLocation;

    public float bulletSpeed = 25.0f;
    public float bulletDamage;
    // public float fireRate = 1; // TODO
    public int dynamites = 6; // how many the player has

    PlayerUI playerUI;

    AudioSource weaponAudio;

    void Start()
    {
      playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>();
      playerUI.SetDynamite(dynamites);
        weaponAudio = this.GetComponent<AudioSource>();
        weaponAudio.clip = GameObject.Find("Sound Manager").gameObject.GetComponent<SoundManager>().playerSounds[2];
    }

    void Update() { Controls(); }

    private void Controls()
    {
      if ( Input.GetMouseButtonDown(0) ) // left click for now
      {
        playerLocation = this.transform.position;
        Vector2 target = Camera.main.ScreenToWorldPoint( new Vector2(Input.mousePosition.x, Input.mousePosition.y) );
        // create a bullet by cloning the prefab
        GameObject bullet = Instantiate(bulletPrefab, playerLocation + new Vector2(GetPlayerDirection()*0.5f,0), Quaternion.identity);
        // prevent bullet from colliding with the player
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        // tell the bullet how much damage it's supposed to deal
        bullet.GetComponent<BulletLogic>().setBulletDamage(bulletDamage);

        Vector2 direction = target - playerLocation;
        direction.Normalize();
        bullet.GetComponent<Rigidbody2D>().velocity =  direction * bulletSpeed;
            weaponAudio.Play(0);
      }

      if ( Input.GetMouseButtonDown(1) ) // right click for now
      {
        if ( dynamites > 0 )
        {
          playerLocation = new Vector3(this.transform.position.x + GetPlayerDirection() * 0.5f, this.transform.position.y, 0);
          GameObject dynamite = Instantiate(dynamitePrefab, playerLocation, Quaternion.identity);
          // "send" information to DynamiteLogic script for logic handling

          dynamites--;
          playerUI.SetDynamite(dynamites);
        }

        // TODO: if player has no dynamites left,
        // play a sound and / or inform the player elsehow
        else
        {
          print("TODO: you got no dynamites left!");
        }
      }
    }

    float GetPlayerDirection() {
        // -1 == left, 1 == right
        if (GameObject.Find("gun").transform.position.x > this.gameObject.transform.position.x) return 1;
        else return -1;
    }
}
