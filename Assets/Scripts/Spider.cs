using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spider : MonoBehaviour
{
    public float speed;
    public float health;
    float Maxhealth;
    private Transform target;
    float deathTimer = 3.0f;
    public GameObject deathParticles;
    public Canvas healthBar;
    RectTransform healthBarLocation;
    public int points;
    Vector2 distanceToPlayer;
    GameObject player;
    public Vector2 triggerDistance = new Vector2(5, 2);
    public Animator animator;
    bool isAlive = true;
    int damage = 20;
    GameObject soundmanager;
    AudioSource audioPlayer;


    void Start()
    {
        GetComponent<Rigidbody2D>().simulated = true; //start gameobject with no gravity
        player = GameObject.Find("Player"); //find where player is
        gameObject.tag = "enemy";    //tagging this as an enemy
        gameObject.name = "Spider"; //Make sure that gameobjects name si spider if needed in the future
        deathParticles.SetActive(false);  // start with deathparticle sequence turned off
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); //find player
        healthBarLocation = healthBar.GetComponent<RectTransform>(); //store healtbarlocation info
        Maxhealth = health;
        soundmanager = GameObject.Find("Sound Manager");
        audioPlayer = this.GetComponent<AudioSource>();
        
    }
    

    void Update()
    {
        CheckHealth();
        CheckDistanceToPlayer();
    
    }

    public void DeathCycle() 
    {
        isAlive = false;
        this.gameObject.transform.rotation = Quaternion.Euler(new Vector3 (180, 0, 0)); // flip object over x-axis by 180 degrees
        if (deathTimer > 0) //while death cycle time is more than 0
        {
            deathTimer -= Time.deltaTime; //make timer go down
            deathParticles.SetActive(true); //start death particle cycle
            healthBar.gameObject.SetActive(false); //remove healthbar on death

        }
        else
        {
            Destroy(gameObject); //remove gameobject from game
            GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerUI>().SetPoints(points); //add points accordingly
        }

    }
    public void CheckHealth()
    {
        if (health <= 0) //if health is below 0
        {

            DeathCycle(); //start deathcycle
        }
        else
        {
           
            healthBarLocation.position = transform.position; //make healthbar follow enemy
            healthBar.GetComponentInChildren<Slider>().value = health; //adjust slider by current healthvalue

            if (health < Maxhealth && isAlive)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime); //if npc takes damage, starts following player
                animator.SetBool("isAwake", true);
            }
            
           
        }
    }

    public void CheckDistanceToPlayer()
    {
        distanceToPlayer = transform.position - player.transform.position; //check the distance to player
          
        //Check distance in x- and y-axis
        if (distanceToPlayer.x < triggerDistance.x && distanceToPlayer.y < triggerDistance.y && isAlive)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().simulated = true;
            animator.SetBool("isAwake", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().TakeDamage(damage);
        }
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            audioPlayer.clip = soundmanager.GetComponent<SoundManager>().enemySounds[0];
            audioPlayer.Play(0);
        }
    }


}
