using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
  public Image image;
  public void SetFill(float value)
  {
    image.fillAmount = value;
  }
}
