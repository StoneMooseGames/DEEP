using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour
{
    public Image healthBar;
    public TextMeshProUGUI time;
    public TextMeshProUGUI dynamite;
    public TextMeshProUGUI points;
    public Slider healthSlider;


    public void SetHealthFill(float value)
  {
        //healthBar.fillAmount = value;
        healthSlider.value = value;
  }

  public void SetDynamite(int value)
  {
    dynamite.text = value.ToString();
  }
  public void SetPoints(int value)
    {

        int.TryParse(points.text, out int temp); //points text is a string, so parse it to int temporarily
        temp = temp + value; //add incoming points to temp
        points.text = temp.ToString(); //turn int value back to string and change the text string to correspond right amount of points
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape")) SceneManager.LoadScene("Menu"); //Escape key loads Menu

    }
  public void SetTime(float text)
  {
    this.time.text = text.ToString();
  }

}
