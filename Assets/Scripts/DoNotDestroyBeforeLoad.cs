using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroyBeforeLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
