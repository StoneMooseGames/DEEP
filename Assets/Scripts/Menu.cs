using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private void Start()
    {
        Destroy(GameObject.Find("UI"));
        Destroy(GameObject.Find("Sound Manager"));
    }
    public void PressStart()
  {
    SceneManager.LoadScene("level1"); 
  }
    public void PressExit()
  {
    Application.Quit();
  }
    public void StartTutorial()
    {
        SceneManager.LoadScene("tutoriallevel");
    }
}
