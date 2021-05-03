using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class tutorialManager : MonoBehaviour
{
    public GameObject[] tutorials;
    int tutorialStage = 0;
    GameObject player;
    public GameObject endObject;
    float timer = 2.0f;
    bool timerState = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Player");
        

        for (int i = 0; i < tutorials.Length; i++)
        {
            tutorials[i].GetComponent<TMP_Text>().text = "";
        }
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
        // Check if timer is on or not and send StartTimer current tutorial stage
        StartTimer(timerState,tutorialStage);

            if(tutorialStage == 0 && !timerState) //check what stage and if timer is off
            {
                tutorials[0].GetComponent<TMP_Text>().text = "Press A and D to move left and right";
                timerState = true; //start timer
            }


            if (Input.GetAxisRaw("Horizontal") !=0 && tutorialStage == 1)
            {
                tutorials[0].GetComponent<TMP_Text>().text = "";
                tutorials[1].GetComponent<TMP_Text>().text = "Press Space to use jetpack";
                timerState = true;
                
            }

            if (Input.GetKey("space") && tutorialStage == 2)
            {
                tutorials[1].GetComponent<TMP_Text>().text = "";
                tutorials[2].GetComponent<TMP_Text>().text = "Press Left mouse button to fire";
                timerState = true;
            }

            if (Input.GetMouseButtonDown(0) && tutorialStage == 3)
            {
                tutorials[1].GetComponent<TMP_Text>().text = "";
                tutorials[2].GetComponent<TMP_Text>().text = "Press Right mouse button to drop dynamite";
                timerState = true;
            }

            if (Input.GetMouseButtonDown(1) && tutorialStage == 4)
            {
                tutorials[1].GetComponent<TMP_Text>().text = "";
                tutorials[2].GetComponent<TMP_Text>().text = "Find the lost miner";
                timerState = true;
            }

            if(player.GetComponent<Collider2D>().IsTouching(endObject.GetComponent<Collider2D>()))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    public void StartTimer(bool stateOfTimer, int stateOfTutorial) //import if timer is on or off and what stage tutorial is in
    {
        if (stateOfTimer) //check if timer is on
        {
            timer -= Time.deltaTime; // minus time from timer
            if (timer < 0) // when timer hits 0, make timerState inactive, reset time to 4sek and set new tutorial Stage
            {
                timerState = false;
                timer = 4.0f;
                tutorialStage = stateOfTutorial + 1;
            }
        }
    }

    
}
