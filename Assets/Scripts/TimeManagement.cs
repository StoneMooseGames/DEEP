using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagement : MonoBehaviour
{

  static float timer = 0;
    // Update is called once per frame
  void Update()
    {
      timer += Time.deltaTime;
      GameObject UI = GameObject.FindGameObjectWithTag("PlayerUI");
      UI.GetComponent<PlayerUI>().SetTime((int)timer);
    }
}
