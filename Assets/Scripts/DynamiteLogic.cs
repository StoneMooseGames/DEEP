using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DynamiteLogic : MonoBehaviour
{
    public float fuseTime;
    public float explosionRadius;
    AudioSource explosionSound;
    SpriteRenderer spriteRenderer;
    SoundManager soundmanager;

    void Start()
    {
      explosionSound = GetComponent<AudioSource>();
      spriteRenderer = GetComponent<SpriteRenderer>();
      explosionSound.clip = GameObject.Find("Sound Manager").GetComponent<SoundManager>().playerSounds[0];
    }

    void Update()
    {
      fuseTime -= Time.deltaTime;
      if ( fuseTime <= 0 ) Explode();
    }

    void Explode()
    {
      if ( !explosionSound.isPlaying )
      {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll( this.gameObject.transform.position, explosionRadius );
        foreach ( var hitCollider in hitColliders )
        {
                if (hitCollider.tag == "Destroyable") Destroy(hitCollider.gameObject);

                else if (hitCollider.name == "Player")
                {
                    GameObject.Find("Player").gameObject.GetComponent<PlayerMovement>().TakeDamage(50);
                }
                else if (hitCollider.name == "Spider")
                {
                    GameObject.Find("Spider").gameObject.GetComponent<Spider>().health -= 50;
                }
            }

        explosionSound.Play(); // play audio
        // because Destroy is delayed so that the audio is played correctly,
        // the sprite will be visible too long. Hence we hide the object and destroy it later
        spriteRenderer.enabled = false;
        Destroy( this.gameObject, explosionSound.clip.length );
      }
    }
}
