using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroyer : MonoBehaviour
// this is a destroyer script for the falling apples that keep stacking on top of each other lol- might use this for the ants that keep spawning too lol.
{
    public float delay = 10f; 

    void Start()
    {
        
        Invoke("Disappear", delay);
    }

    void Disappear()
    {
        gameObject.SetActive(false); //this diddn't work for the other destroyer so i hope it works for this
    }
}

