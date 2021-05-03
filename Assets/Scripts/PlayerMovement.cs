using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour
{
  public float speed = 2.0f;
  public float jetpackForce = 1.0f;
  public int health = 200;
  public Animator animator;
  private GameObject playerUI;

  private int levelNumber;
  private float horizontalmove = 0f;
  private Vector3 velocity = Vector3.zero;
  private Rigidbody2D rb;
  private bool is_jumping;
  private AudioSource playerAudio;
  private AudioClip jetPackClip;
  
  void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerUI = GameObject.FindGameObjectWithTag("PlayerUI");
        playerAudio = this.GetComponent<AudioSource>();
        jetPackClip = GameObject.Find("Sound Manager").gameObject.GetComponent<SoundManager>().playerSounds[1];
        
    }

  void Update()
    {
        Controls();
        animator.SetFloat("Speed", Mathf.Abs(horizontalmove));
    }

  void FixedUpdate() {
    Vector3 targetVelocity = new Vector2(horizontalmove * 10f * Time.fixedDeltaTime, rb.velocity.y);
    rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0f);

    if ( is_jumping ) {
      rb.AddForce(new Vector2(0f, jetpackForce));
      is_jumping = false;
           
        }
  }
    private void Controls()
    {
        horizontalmove = Input.GetAxisRaw("Horizontal") * speed;
        if (horizontalmove < 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (horizontalmove > 0)
        {
            this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey("space"))
        {
            is_jumping = true;
            GameObject.Find("jetFlame1").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("jetFlame1").gameObject.GetComponent<AudioSource>().enabled = true;
            if (!GameObject.Find("jetFlame1").gameObject.GetComponent<AudioSource>().isPlaying) GameObject.Find("jetFlame1").gameObject.GetComponent<AudioSource>().Play(0);
        }
        else
        {
            GameObject.Find("jetFlame1").gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("jetFlame1").gameObject.GetComponent<AudioSource>().enabled = false;
        }


        }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    //Check if playercollider enters another collider(as trigger)
    if (collision.gameObject.tag == "endlevel")
    {
      if (SceneManager.GetActiveScene().name.Length <= 6) //Check how long is name name of the scene
      {
        double tempNumber = Char.GetNumericValue(SceneManager.GetActiveScene().name[5]); //Get the 6th character from the scene.name
        levelNumber = (int)(tempNumber); //turn it into integer
        levelNumber++; //add one to levelnumber
        SceneManager.LoadScene("level" + levelNumber); //Load next scene
        if(levelNumber == 9) // if level is 9 it needs to be checked so that naming can turn to double digits
        {
          SceneManager.LoadScene("level" + 10); //Load next scene
        }
      }
      if (SceneManager.GetActiveScene().name.Length == 7)
      {
        int tempNumber1 = (int)(Char.GetNumericValue(SceneManager.GetActiveScene().name[5])); //same as before, just shortened
        int tempNumber2 = (int)(Char.GetNumericValue(SceneManager.GetActiveScene().name[6]));
        tempNumber2++;
        SceneManager.LoadScene("level" + tempNumber1 + tempNumber2); //Load next scene
      }
      Debug.Log("Current level:" + SceneManager.GetActiveScene().name); //print levelnumber to the console
    }

    if(collision.gameObject.tag == "tempendlevel")
        {
            SceneManager.LoadScene("Menu");
        }
  }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        playerUI.GetComponent<PlayerUI>().SetHealthFill(health);
        if (health <= 0) startPlayerDeathSequence();
    }
    private void startPlayerDeathSequence()
    {
        SceneManager.LoadScene("Menu");
    }

}
